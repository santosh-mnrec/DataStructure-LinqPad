

void Main()
{
	LinkedList list = new LinkedList();
	list.Insert(1);
	list.Insert(-1);
	list.Insert(-2);
	list.Insert(100);
	list.Insert(-100);
	list.Dump();
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

	public void Insert(int data)
	{
		Node newNode = new Node(data);
		Node current;
		/* Special case for head node */
		if (_head == null || _head.Data >= newNode.Data)
		{
			newNode.Next = _head;
			_head = newNode;
		}
		else
		{

			/* Locate the node before point of insertion. */
			current = _head;

			while (current.Next != null && current.Next.Data < newNode.Data)
				current = current.Next;

			newNode.Next = current.Next;
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