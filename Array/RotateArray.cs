


void Main()
{
	var arr=new[]{1,2,3,4,5};
	rotate(arr,2);
	arr.Dump();
}

// Define other methods and classes here
public static void rotate(int[] arr, int order) {
	if (arr == null || order < 0) {
	    throw new Exception("Illegal argument!");
	}
 
	for (int i = 0; i < order; i++) {
		for (int j = arr.Length - 1; j > 0; j--)
		{
			int temp = arr[j];
			arr[j] = arr[j - 1];
			arr[j - 1] = temp;
			arr.Dump("First Swap");
		}
	}
}