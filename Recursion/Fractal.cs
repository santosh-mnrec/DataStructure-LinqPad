
/* Idea and clojure from http://nakkaya.com/2010/04/20/fractals-in-clojure-newton-fractal */
//Func<Complex, Complex> f1 = c => (c * c * c) - Complex.One;
Func<Complex, Complex> f2 = c => ((c * c * c) - (c * 2)) + 2;
Func<Complex, Complex> f3 = c => new Complex(Math.Sin(c.Real) * Math.Cosh(c.Imaginary),
											 Math.Cos(c.Real) * Math.Sinh(c.Imaginary));
Func<Complex, Complex> f4 = c => (c * c * c * c) - Complex.One;

double step = 0.000006;
double delta = 0.003;
Tuple<int, int> formDimensions = new Tuple<int, int>(800, 600);
Tuple<double, double, double, double> complexPane = new Tuple<double, double, double, double>(-1.3d, 1.4d, -1.0d, 1.0d);

Func<Complex, Complex> activeFunction = null;

[STAThread]
void Main()
{
	activeFunction = f2;

	Form form = new Form();
	form.Width = formDimensions.Item1;
	form.Height = formDimensions.Item2;
	form.ResizeEnd += (sender, evt) => formDimensions = new Tuple<int, int>(((Control)sender).Size.Width, ((Control)sender).Size.Height);
	form.Paint += (sender, evt) => Draw(activeFunction, evt.Graphics);
	form.Show();

	var g = form.CreateGraphics();
	Draw(activeFunction, g);

	form.Show();
	form.Activate();
	Application.Run(form);
}

Bitmap Newton(Func<Complex, Complex> f, double step, double delta, Tuple<int, int> dimensions, Tuple<double, double, double, double> complexPane)
{
	var width = dimensions.Item1;
	var height = dimensions.Item2;
	var xa = complexPane.Item1;
	var xb = complexPane.Item2;
	var ya = complexPane.Item3;
	var yb = complexPane.Item4;
	var sw = new Stopwatch();
	sw.Start();
	var results = new int[width, height];

	var b = new Bitmap(width, height);
	Parallel.For(0, width, x =>
	{
		Parallel.For(0, height, y =>
		{
			var zx = (((xb - xa) * x) / (width - 1)) + xa;
			var zy = (((yb - ya) * y) / (height - 1)) + ya;
			var c = Converge(f, new Complex(zx, zy), step, delta);
			results[x, y] = c;
		});
	});

	Console.WriteLine("Newton took: " + sw.ElapsedMilliseconds + "ms.");
	sw.Restart();
	for (int y = 0; y < height; y++)
	{
		for (int x = 0; x < width; x++)
		{
			var c = results[x, y];
			var color = Color.FromArgb(255, (c % 4) * 64, (c % 8) * 32, (c % 16) * 16);
			b.SetPixel(x, y, color);
		}
	}
	Console.WriteLine("Bitmap creation took: " + sw.ElapsedMilliseconds + "ms.");
	return b;
}

int Converge(Func<Complex, Complex> f, Complex c, double step, double delta)
{
	Func<Complex, Complex> dz = p => (f(p + new Complex(step, step)) - f(p)) / new Complex(step, step);
	Func<Complex, Complex> iter = p => Complex.Subtract(p, Complex.Divide(f(p), dz(p)));

	var lz = c;
	var z = iter(c);
	for (int i = 0; i <= 32; i++)
	{
		if (i > 31 || Complex.Abs(Complex.Subtract(z, lz)) < delta)
			return i;

		lz = z;
		z = iter(z);
	}
	return 32;
}

void Draw(Func<Complex, Complex> f, Graphics graphics)
{
	var sw = new Stopwatch();
	sw.Start();

	var fractalBitmap = Newton(f, step, delta, formDimensions, complexPane);
	graphics.DrawImage(fractalBitmap, 0, 0);

	Console.WriteLine("Finished Drawing after " + sw.ElapsedMilliseconds + "ms.");
}