

void Main()
{
	var arr = new[] { -1, 2, 1, 99, 11 };

	Console.WriteLine("Before Sorting");
	Print(arr);
	Console.WriteLine("After Sorting");
	SelectionSort(arr);
	Print(arr);
}

void SelectionSort(int[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		int minIndex = i;
		for (int j = i + 1; j < arr.Length; j++)
		{
			if (arr[minIndex] >arr[j])
				minIndex = j;
		}
		if (minIndex != i)
		{
			int temp=arr[i];
			arr[i]=arr[minIndex];
			arr[minIndex]=temp;
		}

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