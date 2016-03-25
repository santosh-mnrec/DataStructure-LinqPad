<Query Kind="Program" />

void Main()
{
	List l = new List(1);
	l.Next = new List(2);
	l.Next.Next = new List(3);
	l.Next.Next.Next = new List(3);
	l.Next.Next.Next.Next = new List(4);
	l.Dump();
	l.Duplicate();
	l.Dump();

}

public class List
{
	public List Next { get; set; }
	public int Data { get; set; }
	public List(int data)
	{
		this.Next = null;
		this.Data = data;
	}
	public override string ToString()
	{
		List current = this;
		StringBuilder builder = new StringBuilder();
		while (current != null)
		{
			builder.Append(current.Data + "->");
			current = current.Next;
		}
		builder.Append("NULL");
		return builder.ToString();
	}
	public void Duplicate()
	{
		//1->2->3->3->4-NULL

		List outer = this;
		List inner = null;
		List dup = null;
		while (outer.Next != null)
		{
			inner = outer;
			while (inner.Next != null)
			{
				if (outer.Data == inner.Next.Data)
				{
					dup = inner.Next;
					Console.WriteLine("Duplicate"+dup.Data);
					outer.Next = inner.Next.Next;
				}
				inner = inner.Next;
			}
			outer = outer.Next;

		}
	}

}