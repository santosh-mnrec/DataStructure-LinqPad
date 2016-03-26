<Query Kind="Program" />

void Main()
{
	int sum = 0;
	Sum(new[] { 1, 2, 3, 4 ,11}, 4).Dump();
}

int Sum(int[] arr, int n)
{
	if (n==0)
		return arr[0];

return arr[n]+Sum(arr,n-1);
}
int Sum(int[] arr, int n, int sum)
{

	if (n < 0)
	{
		return sum;
	}
	else
	{
		sum += arr[n];
	}

	return Sum(arr, --n, sum);
}