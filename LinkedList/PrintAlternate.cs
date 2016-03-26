
void Main()
{
	LinkedList list = new LinkedList();
	list.AddLast(1);
	list.AddLast(2);
	list.AddLast(3);
	list.AddLast(10);
	list.AddLast(11);
	list.AddLast(12);
	list.AddLast(13);
	Console.WriteLine(list);
	list.PrintAlternate();
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

	public void PrintAlternate()
	{
		Node current = _head;
		int count = 0;
		while (current != null)
		{
			if (count % 2 == 0)
				Console.Write(current.Data + "->");
			current = current.Next;
			count = count + 1;
		}
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