<Query Kind="Program" />

void Main()
{
	Queue q = new Queue();
	q.Enqueue(1);
	q.Enqueue(2);
	q.Enqueue(3);
	q.Dequeue();
	q.Dequeue(); q.Dequeue();
	q.Dequeue(); q.Dequeue();
	q.Dequeue(); q.Dequeue();
	q.Dequeue();
	q.Enqueue(3); q.Enqueue(3);q.Enqueue(3);q.Enqueue(3);q.Enqueue(3);q.Enqueue(3);
	q.Display();
}

public class Queue
{
	private int[] arr;
	private int size = 10;
	private int front = -1;
	private int rear = -1;
	public Queue()
	{
		arr = new int[size];
	}
	public void Display()
	{
		for (int i = front; i <=rear; i++)
		{
			Console.Write(arr[i] +",");
		}
		Console.WriteLine();
	}
	public int Dequeue()
	{
		int element = -1;
		if ((front == rear) && rear == -1)
		{
			Console.WriteLine("Empty");

		}
		else
		{
			element = arr[front];
			if (front == rear)
				front = rear - 1;
			else
				front = (front + 1) % size;

		}
		return element;
	}
	public void Enqueue(int item)
	{
		if ((front == (rear + 1) % size))
		{
			Console.WriteLine("Overflow");
		}
		else
		{
			rear = (rear + 1) % size;
			arr[rear] = item;
			if (front == -1)
				front = 0;
		}
	}
}