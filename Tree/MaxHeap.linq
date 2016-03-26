<Query Kind="Program" />

void Main()
{

}


public class MaxHeap
{
	int[] heap;
	int heapSize = 0;
	public MaxHeap()
	{

	}
	private void maxHeapify(int[] inputData)
	{

		heap = new int[inputData.Length + 1];
		//fill the heap from 1 index to make life easier

		//if a parent node is at ith index the the left child is at 2*i and right child is at
		//2*i+1
		//insert from the back to the front

		for (int i = 0; i < inputData.Length; i++)
		{
			heap[heapSize + 1] = inputData[i];

			Heapify(inputData[i]);
			++heapSize;
		}
	}
	private void Heapify(int value/*, int[] data*/)
	{

		//int index = data.length-1;
		int index = heapSize + 1;
		//System.out.println("index "+index+" heap[index/2]"+heap[index/2]);
		while (index > 1 && heap[index / 2] < value)
		{
			//swap parent with child
			int temp = heap[index / 2];
			heap[index / 2] = heap[index];
			heap[index] = temp;

			index /= 2;
		}

	}
	public void Add(int value)
	{
		int index = heapSize + 1;
		if (index >= heap.Length)
			Array.Copy(heap, heap, heapSize + 16);
		heap[index] = value;

		while (index > 1 && heap[index / 2] < heap[index])
		{
			//swap parent with child
			int temp = heap[index / 2];
			heap[index / 2] = heap[index];
			heap[index] = temp;

			index /= 2;
		}
	}
	public int RemoveMax()
	{
		if (heapSize == 0)
			throw new Exception("The heap is empty");
		int result = -1;
		result = heap[1];
		heap[1] = heap[heapSize];
		--heapSize;
		//now balance the heap according to the max heap property
		for (int i = 1; i < heapSize; i *= 2)
		{
			if (i * 2 < heapSize && heap[i] < heap[i * 2] && heap[i * 2] > heap[i * 2 + 1])
			{
				//swap the two elements
				int max = heap[i * 2];
				heap[i * 2] = heap[i];
				heap[i] = max;
			}
			else if (i * 2 + 1 < heapSize && heap[i] < heap[i * 2 + 1])
			{
				int max = heap[i * 2 + 1];
				heap[i * 2 + 1] = heap[i];
				heap[i] = max;
			}
		}
		//Console.WriteLine(Array..toString(heap));
		return result;
	}

}
