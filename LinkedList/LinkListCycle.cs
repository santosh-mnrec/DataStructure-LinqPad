
void Main()
{
	LinkedList list = new LinkedList();
	list.AddLast(1);
	list.AddLast(2);
	var r=list.AddFirst(5);
	list.Head.Next.Next=r;
	list.Cycle().Dump();
	//list.Dump();
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

	public Node Head
	{
		set
		{
			_head=value;
		}
		get
		{
			return _head;
		}
	}
	public bool Cycle()
	{
		Node slow = _head;
		Node fast = _head;
		//1->2->3->4-5>NULL
		while (slow != null && fast.Next != null)
		{
			slow = slow.Next;
			fast = fast.Next.Next;

			if (slow == fast)
				return true;
		}
		return false;

	}
	public Node AddFirst(int data)
	{
		//1->2-3
		Node newNode = new Node(data);
		if (_head == null)
			_head = newNode;
		newNode.Next = _head;
		_head = newNode;
		
		return _head;


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
