


void Main()
{
	int[] arr = new[] { 11, 1, 2, 1212, -1, 9, -99999 };
	MergeSort(arr, 0, 6);
	arr.Dump();

}
public void MergeSort(int[] A, int lo, int hi)
{
	if (lo < hi)
	{ //list contains at least 2 elements
		int mid = (lo + hi) / 2; //get the mid-point subscript
		MergeSort(A, lo, mid); //sort first half
		MergeSort(A, mid + 1, hi); //sort second half
		Merge(A, lo, mid, hi); //merge sorted halves
	}
} //end mergeSort
public void Merge(int[] A, int lo, int mid, int hi)
{
	//A[lo..mid] and A[mid+1..hi] are sorted;
	//merge the pieces so that A[lo..hi] are sorted
	int[] T = new int[hi - lo + 1];
	int i = lo, j = mid + 1;
	int k = 0;
	while (i <= mid || j <= hi)
	{
		if (i > mid) T[k++] = A[j++];
		else if (j > hi) T[k++] = A[i++];
		else if (A[i] < A[j]) T[k++] = A[i++];
		else T[k++] = A[j++];
	}
	for (j = 0; j < hi - lo + 1; j++) A[lo + j] = T[j];
} //end merge
 
        