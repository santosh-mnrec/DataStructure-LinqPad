<Query Kind="Program" />

public class Node
{
	public Node Next { get; set; }
	public int Data { get; set; }
	public Node(int data)
	{
		this.Data = data;
	}
	public override string ToString()
	{
		Node current = this;
		StringBuilder builder = new StringBuilder();
		while (current != null)
		{
			builder.Append(current.Data + "->");
			current = current.Next;
		}
		return builder.ToString();


	}
	//Traverse linked list using two pointers. Move one pointer by one and other pointer by two. When the fast pointer
	//reaches end slow pointer will reach middle of the linked list.
	public Node Reverse(Node head, int k)
	{
		Node current = head;
		Node next = null;
		Node prev = null;
		int count = 0;
		while (current != null && count < k)
		{

			next = current.Next;
			current.Next = prev;
			prev = current;
			current = next;
			count++;
		}
		if (next != null)
		{
			head.Next = Reverse(next, k);
		}
		return prev;


	}
}

void Main()
{
	Node node = new Node(10);
	node.Next = new Node(20);
	node.Next.Next = new Node(30);
	node.Next.Next.Next = new Node(40);
	node.Reverse(node, 2);

}