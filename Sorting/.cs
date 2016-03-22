<Query Kind="Program" />

void Main()
{
	var arr = new[] { -1, 2, 1, 99, 11 };

	Console.WriteLine("Before Sorting");
	Print(arr);
	Console.WriteLine("After Sorting");
	BubbleSort(arr);
	Print(arr);
}

void BubbleSort(int[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		for (int j = 0; j < arr.Length - i - 1; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				int temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}

}

void Print(int[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		Console.Write("--");
		Console.Write(arr[i] + "|");
		Console.Write("--");
	}
	Console.WriteLine();
}