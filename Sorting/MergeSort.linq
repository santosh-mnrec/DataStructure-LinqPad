<Query Kind="Program" />

void Main()
{
	var a = new[] { -1, 1, 2, -43, 44, 22};
	MergeSort2(a);
	a.Dump();
}
static void MergeSort2(int[] arr)
{
  int[] helper=new int[arr.Length];
  MergeSort(arr,helper,0,arr.Length-1);
  arr.Dump();
}

static void MergeSort(int[] arr, int[] helper, int low, int high)
{
	if (low < high)
	{
		int mid = (low + high) / 2;
		MergeSort(arr, helper, low, mid);
		MergeSort(arr, helper, mid + 1, high);
		Merge(arr, helper, low, mid, high);
	}

}
public static void Merge(int[] arr, int[] helper, int low, int mid, int high)
{
	for (int i = low; i <= high; i++)
	{
		helper[i] = arr[i];
	}
	int left = low;
	int right = mid + 1;
	int current = low;
	while (left < mid && right <= high)
	{

		if (helper[left] <= helper[right])
		{
			arr[current] = helper[left];
			left++;
		}
		else
		{
			arr[current]=helper[right];
			right++;
		}
		current++;


	}
	//Copy reman
	
	int remaining=mid-left;
	
	for (int i = 0; i <=remaining; i++)
	{
		arr[current+1]=helper[left+i];
	}

}