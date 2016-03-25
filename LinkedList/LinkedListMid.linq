<Query Kind="Program" />

void Main()
{
	LinkedList list = new LinkedList();
	list.AddLast(1);
	list.AddLast(2);
	list.AddLast(3);
	list.AddLast(10);
	list.AddLast(11);
	

	Console.WriteLine(list);
	list.FindMin().Data.Dump();
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
	public Node(int data)
	{
		this.Data = data;
		this.Next = null;
	}

}

public class LinkedList
{

	private Node _head;
	public LinkedList() { }

	public Node FindMin()
	{
		Node current = _head;
		Node fast = _head;
		Node slow = _head;
		while (fast != null && slow != null && fast.Next != null)
		{
			slow = slow.Next;
			fast = fast.Next.Next;
       }
		return slow;
	}
	public void AddLast(int data)
	{
		Node newNode = new Node(data);
		if (_head == null)
			_head = newNode;
		else
		{
			Node current = _head;
			while (current.Next != null)
			{
				current = current.Next;
			}
			current.Next = newNode;
		}
	}
	public override string ToString()
	{
		StringBuilder builder = new StringBuilder();
		Node current = _head;
		while (current != null)
		{
			builder.Append(current.Data + "->");
			current = current.Next;

		}
		builder.Append("NULL");
		return builder.ToString();
	}

}