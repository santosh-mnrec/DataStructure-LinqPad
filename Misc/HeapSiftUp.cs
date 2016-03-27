public class SiftUpTest
{
	static int MaxHeapSize = 100;
	public static void Main(String[] args)
	{
		int[] num = new int[MaxHeapSize + 1];
		int n = 0, number;
		FileStream fs = new FileStream(@"heap.in", FileMode.Open);
		var result = new StreamReader(fs).ReadToEnd().Split(' ').ToList().ConvertAll(x => Convert.ToInt32(x)).ToArray();
		for (int i = 0; i < result.Length; i++)
		{
			number = result[i];
			if (n < MaxHeapSize)
			{ //check if array has room
				num[++n] = number;
				SiftUp(num, n);
			}
		}

		for (int h = 1; h <= n; h++)
			Console.Write(num[h] +",");
		Console.WriteLine();

	} //end main

	public static void SiftUp(int[] heap, int n)
	{
		//heap[1] to heap[n-1] contain a heap
		//sifts up the value in heap[n] so that heap[1..n] contains a heap
		int siftItem = heap[n];
		int child = n;
		int parent = child / 2;
		while (parent > 0)
		{
			if (siftItem <= heap[parent]) break;
			heap[child] = heap[parent]; //move down parent
			child = parent;
			parent = child / 2;
		}
		heap[child] = siftItem;
	} //end siftUp

} //end class SiftUpTest
