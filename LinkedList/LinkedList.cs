
void Main()
{
	LinkedList list = new LinkedList();
	list.AddLast(1);
	list.AddLast(2);
	list.AddFirst(3);
	list.AddFirst(13);
	list.AddFirst(33);
	list.Dump("Before");
	list.Delete(33);
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

	public void Delete(int key)
	{
		Node prev = null;
		Node current = _head;
		bool found = false;
		if (current != null && current.Data == key)
		{
			_head=current.Next;
			return;

		}
		while (current.Next != null && !found)
		{
			if (current.Data == key)
			{
				prev.Next = current.Next;
				Console.WriteLine(current.Data + " Item Deleted");
				found = true;
			}
			else
			{
				prev = current;
				current = current.Next;
			}
		}
		if (!found)
			Console.WriteLine("Item was not in the list");

	}
	public void Search(int key)
	{
		Node current = _head;
		bool found = false;
	
		while (current.Next != null && found == false)
		{
			if (current.Data == key)
			{
				Console.WriteLine(current.Data + "Found");

				found = true;
			}
			current = current.Next;
		}
		if (!found)
		{
			Console.WriteLine("Not found");
		}

	}
	public void AddFirst(int data)
	{
		//1->2-3
		Node newNode = new Node(data);
		if (_head == null)
			_head = newNode;
		newNode.Next = _head;
		_head = newNode;


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