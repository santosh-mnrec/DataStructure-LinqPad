<Query Kind="Program" />

void Main()
{
	var arr = new[] { 1, 2, 3,9, 4, 5};
	int low=0;
	int high=arr.Length-1;
	ReverseArray(arr,0,high);
	arr.Dump();
}

public static void ReverseArray(int[] data, int low, int high)
{
	if (low < high)
	{ // if at least two elements in subarray
		int temp = data[low]; // swap data[low] and data[high]
		data[low] = data[high];
		data[high] = temp;
		ReverseArray(data, low + 1, high - 1); // recur on the rest
	}
}
