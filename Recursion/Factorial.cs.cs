

void Main()
{
	Factorial(-1).Dump();
}

int Factorial(int n)
{
	if (n < 0 || n == 1)
		return 1;
	return n * Factorial(n - 1);
}
