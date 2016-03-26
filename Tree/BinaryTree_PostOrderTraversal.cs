<Query Kind="Program" />

void Main()
{
	BinaryTree tree = new BinaryTree(10);
	tree.Left = new BinaryTree(2);
	tree.Right = new BinaryTree(20);
	tree.Left.Left = new BinaryTree(1);
	tree.PostOrder();
	Console.WriteLine();
	tree.PostOrderNonRec();
}

public class BinaryTree
{
	public BinaryTree Left { get; set; }
	public BinaryTree Right { get; set; }
	public int Data { get; set; }
	public BinaryTree(int data)
	{
		this.Data = data;
		this.Left = null;
		this.Right = null;
	}
	public void PostOrderNonRec()
	{
		Stack<BinaryTree> treeNodes = new Stack<UserQuery.BinaryTree>();
		BinaryTree prev = new BinaryTree(10000);
		treeNodes.Push(this);
		while (treeNodes.Count>0)
		{
			var current = treeNodes.Peek();
			if (current == null)
				treeNodes.Pop();
			else if (current.Left == null && current.Right == null)
			{
				Console.Write(current.Data + ",");
					treeNodes.Pop();
			}
			else if (current.Left == prev)
			{
				treeNodes.Push(current.Right);
			}
			else if (current.Right == prev)
			{
				Console.Write(current.Data + ",");
				treeNodes.Pop();
			}
			else
			{
				treeNodes.Push(current.Left);
			}
			prev=current;
		}
	}
	public void PostOrder()
	{
		if (Left != null)
			Left.PostOrder();
		if (Right != null)
			Right.PostOrder();
		if (this != null)
			Console.Write(Data + ",");

	}
}
