<Query Kind="Program" />


void Main()
{
	int[] arr = new[] { 11, 1, 2, 1212, -1, 9, -99999 };
	SortMerge(arr, 0, 6);
	arr.Dump();

}
static public void SortMerge(int[] numbers, int left, int right)
{
	int mid;
	int[] temp = new int[numbers.Length];

	if (right > left)
	{
		mid = (right + left) / 2;
		SortMerge(numbers, left, mid);
		SortMerge(numbers, (mid + 1), right);

		Merge(numbers, temp, left, mid, mid + 1, right);
	}
}
static void Merge(int[] arr, int[] temp, int leftStart, int leftEnd, int rightStart, int rightEnd)
{
	int i = leftStart;
	int j = rightStart;
	int k = leftStart;

	while (i <= leftEnd && j <= rightEnd)
	{
		if (arr[i] < arr[j])
			temp[k++] = arr[i++];
		else
			temp[k++] = arr[j++];
	}
	while (i <= leftEnd)
	{
		temp[k++] = arr[i++];
	}
	while (j <= rightEnd)
		temp[k++] = arr[j++];
	for (i = leftStart; i <= rightEnd; i++)
		arr[i] = temp[i];

}

// Define other methods and classes here