
void Main()
{
	List l = new List(1);
	l.Next = new List(2);
	l.Next.Next = new List(3);

	//l.Dump();
	var r = l.Reverse();
	r.Dump();
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
	public List Reverse()
	{
		List current = this;
		List next = null;
		List prev = null;
		//1->2->3->4-NULL
		while (current != null)
		{
			next = current.Next;

			current.Next = prev;
			prev = current;
			current = next;

		}
		return prev;
	}

}