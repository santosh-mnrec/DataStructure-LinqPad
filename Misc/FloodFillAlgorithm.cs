

void Main()
{
	int[,] screen = {{1, 1, 1, 1, 1, 1, 1, 1},
					  {1, 1, 1, 1, 1, 1, 0, 0},
					  {1, 0, 0, 1, 1, 0, 1, 1},
					  {1, 2, 2, 2, 2, 0, 1, 0},
					  {1, 1, 1, 2, 2, 0, 1, 0},
					  {1, 1, 1, 2, 2, 2, 2, 0},
					  {1, 1, 1, 1, 1, 2, 1, 1},
					  {1, 1, 1, 1, 1, 2, 2, 1},
					 };
	int x = 4, y = 4, newC = 3;
	floodFill(screen, x, y, newC);

	"Updated screen after call to floodFill:".Dump();
	for (int i = 0; i < 8; i++)
	{
		for (int j = 0; j < 8; j++)
			Console.Write(screen[i, j] + " ");
		Console.WriteLine();
	}

}
// A recursive function to replace previous color 'prevC' at  '(x, y)' 
// and all surrounding pixels of (x, y) with new color 'newC' and
void floodFillUtil(int[,] screen, int x, int y, int prevC, int newC)
{
	int M = 8;
	int N = 8;
	// Base cases
	if (x < 0 || x >= M || y < 0 || y >= N)
		return;
	if (screen[x, y] != prevC)
		return;

	// Replace the color at (x, y)
	screen[x, y] = newC;

	// Recur for north, east, south and west
	floodFillUtil(screen, x + 1, y, prevC, newC);
	floodFillUtil(screen, x - 1, y, prevC, newC);
	floodFillUtil(screen, x, y + 1, prevC, newC);
	floodFillUtil(screen, x, y - 1, prevC, newC);
}
// Define other methods and classes here
// It mainly finds the previous color on (x, y) and
// calls floodFillUtil()
void floodFill(int[,] screen, int x, int y, int newC)
{
	int prevC = screen[x, y];
	floodFillUtil(screen, x, y, prevC, newC);
}