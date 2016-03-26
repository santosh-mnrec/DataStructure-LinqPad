

void Main()
{
	Fib(10).Dump();
}

// Non recursive
List<int> FibNonRecursive(int n)
{
	List<int> fibs = new List<int>();
	int first = 0;
	int second = 1;
	fibs.Add(first);
	fibs.Add(second);
	while (n > 0)
	{
		int fib = first + second;
		first = second;
		second = fib;
		fibs.Add(fib);
		n--;
	}
	return fibs;

}
int Fib(int n)
{

	if (n == 0 || n == 1)
		return 1;
	else
		return Fib(n - 1) + Fib(n - 2);
}
