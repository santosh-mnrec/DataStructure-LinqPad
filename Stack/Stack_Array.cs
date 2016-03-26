<Query Kind="Program" />

void Main()
{
	Stack st=new Stack();
	st.Push(2);
	st.Push(3);
	while (!st.IsEmpty())
	{
		Console.WriteLine(st.Pop());
	}

}

class Stack
{
	static int MaxStack = 100;
	static int RogueValue = -999999;
	int top = -1;
	int[] ST = new int[MaxStack];

	public bool IsEmpty()
	{
		return top == -1;
	}

	public void Push(int n)
	{
		if (top == MaxStack - 1)
		{
			Console.WriteLine("\nStack Overflow\n");
			Environment.Exit(0);
		}
		++top;
		ST[top] = n;
	} //end push

	public int Pop()
	{
		if (this.IsEmpty()) return RogueValue; //a symbolic constant
		int hold = ST[top];
		--top;
		return hold;
	}

} //end class Stack
