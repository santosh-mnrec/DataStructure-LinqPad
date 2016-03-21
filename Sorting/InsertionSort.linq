<Query Kind="Program" />

void Main()
{
	var arr = new[] { -1, 2, 1, 99, 11,-2 };

	Console.WriteLine("Before Sorting");
	Print(arr);
	Console.WriteLine("After Sorting");
	InsertionSort(arr);
	Print(arr);
}
/*
for i ← 1 to length(A) - 1
    j ← i
    while j > 0 and A[j-1] > A[j]
        swap A[j] and A[j-1]
        j ← j - 1
    end while
end for
Version 2
 for i = 1 to length(A) - 1
    x = A[i]
    j = i - 1
    while j >= 0 and A[j] > x
        A[j+1] = A[j]
        j = j - 1
    end while
    A[j+1] = x[3]
 end for
*/
void InsertionSort(int[] arr)
{
	for (int i = 1; i < arr.Length; i++)
	{
		int j = i;

		while (j > 0 && arr[j - 1] > arr[j])
		{
			int temp = arr[j];
			arr[j] = arr[j - 1];
			arr[j-1]=temp;
			j--;
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