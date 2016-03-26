
void Main()
{
	List l1 = new List(10);
	l1.Next = new List(20);
	l1.Next.Next = new List(30);
	l1.Next.Next.Next = new List(50);
	Console.WriteLine(l1);
	l1.KthFromEnd(3);


}

public class List
{
	public List Next { get; set; }
	public int Data { get; set; }
	public List(int data)
	{
		this.Data = data;

	}
	//	* Function to get the nth node from the last of a linked list*/
	//void printNthFromLast(struct node* head, int n)
	//{
	//    int len = 0, i;
	//	struct node *temp = head;
	// 
	//    // 1) count the number of nodes in Linked List
	//    while (temp != NULL)
	//    {
	//        temp = temp->next;
	//        len++;
	//    }
	//
	//// check if value of n is not more than length of the linked list
	//if (len < n)
	//	return;
	//
	//temp = head;
	//
	//// 2) get the (n-len+1)th node from the begining
	//for (i = 1; i < len - n + 1; i++)
	//	temp = temp->next;
	//
	//printf("%d", temp->data);
	//
	//return;
-
	public void KthFromEnd(int n)
	{
		List current = this;
		List temp = this;
		int count = 0;

		while (count < n)
		{
			if (current == null)
			{
				Console.WriteLine("{0} is greater than number of nodes in list", n);
				return;
			}
			current = current.Next;
			count = count + 1;
		}
		while (current != null)
		{
			current = current.Next;
			temp = temp.Next;
		}

		Console.WriteLine(temp.Data);

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
}
