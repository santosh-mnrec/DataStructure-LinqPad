
void Main()
{
	var arr = new[] { 2, 0, 0, 1, 1, 10 };
	Reverse(arr);
	arr.Dump();

}
static void Reverse(int[] arr)
{
	int l = 0;
	int r = arr.Length - 1;
	while (l < r)
	{
		Swap(ref arr[l], ref arr[r]);
		l++;
		r--;
	}

}

static void Recursive(int[] arr, int start, int end)
{
	if (start > end)
		return;
	Swap(ref arr[start], ref arr[end]);
	Recursive(arr, ++start, --end);

}
static void Swap(ref int i, ref int j)
{
	int temp = i;
	i = j;
	j = temp;
}
// Define other methods and classes here
