

void Main()
{
	var arr = RandomList(100).ToArray();
	
//	var arr = new[] { 1, -1, 2, -2, -2 };


	Console.WriteLine("Before Sorting");
	Print(arr);
	Console.WriteLine("After Sorting");
	QuickSort(arr, 0, arr.Length - 1);
	Print(arr);
	
}
static List<int> RandomList(int size)
{
	List<int> ret = new List<int>(size);
	Random rand = new Random(1);
	for (int i = 0; i < size; i++)
	{
		ret.Add(rand.Next(size));
	}
	return ret;
}
int Partion(int[] arr, int l, int r)
{
	int left = l;
	int right = r;
	int pivot = arr[left];
	while (left < right)
	{
		while (arr[left] < pivot) left++;
		while (arr[right] > pivot) right--;
		if (left <= right)
		{
			int temp = arr[left];
			arr[left] = arr[right];
			arr[right] = temp;
			left++;
			right--;
		}

	}

	return left;

}
void QuickSort(int[] arr, int left, int right)
{
	int pivotIndex = Partion(arr, left, right);
	if (left < right)
	{
		QuickSort(arr, left, pivotIndex - 1);
		QuickSort(arr, pivotIndex, right);
	}
}

void Print(int[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		Console.Write(arr[i] + "|");

	}
	Console.WriteLine();
}