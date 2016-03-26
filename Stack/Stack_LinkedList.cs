<Query Kind="Program" />

void Main()
{
 Stack st=new Stack();
 st.Push(2);
 st.Push(4);
 Console.WriteLine(st);
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }

	public Node(int d)
	{
		this.Data = d;
		this.Next = null;
	}
}
class Stack
{
	Node top = null;

	public bool IsEmpty()
	{
		return top == null;
	}
	public void Push(int n)
	{
		Node p = new Node(n);
		p.Next = top;
		top = p;
	}
	public int Pop()
	{
		if (this.IsEmpty()) return -1; //a symbolic constant
		int hold = top.Data;
		top = top.Next;
		return hold;
	} //end pop
	public override string ToString()
	{
		Node current = top;
		StringBuilder builder = new StringBuilder();
		while (current != null)
		{
			builder.Append("|" + current.Data + "|");
			current = current.Next;
		}
		return builder.ToString();

	}
}