<Query Kind="Program" />

void Main()
{
	Tree prefixTree = new Tree();

	prefixTree.AddWord("asbc");
	prefixTree.AddWord("abcd");
	prefixTree.AddWord("abcde");
	prefixTree.AddWord("abcdef");
	prefixTree.AddWord("ab123cd");
	prefixTree.AddWord("abc123d");
	prefixTree.AddWord("abc132d");

	string word = "asb";


	if (prefixTree.Find(word))
	{
		var matches = prefixTree.GetMatches(word);

		Console.WriteLine("gasit");
		Console.WriteLine("Autocomplete:");

		if (matches.Count > 0)
			foreach (var m in matches)
				Console.WriteLine(m);
	}
	else
		Console.WriteLine("nu gasii nimic");


}
class Tree
{
	private List<string> subsequentStrings;

	private Node _root;
	public Node Root
	{
		get
		{
			return _root;
		}
	}

	public Tree()
	{
		_root = new Node(' ');
		subsequentStrings = new List<string>();
	}

	public void AddWord(string word)
	{
		char[] chars = word.ToCharArray();
		Node currentNode = _root;
		Node child = null;
		for (int counter = 0; counter < chars.Length; counter++)
		{
			child = currentNode.GetChild(word[counter]);
			if (child == null)
			{
				var newNode = new Node(word[counter]);
				currentNode.Subtree.Add(newNode);
				currentNode = newNode;
			}
			else
				currentNode = child;
			if (counter == chars.Length - 1)
				currentNode.AWordEndsHere = true;
		}
	}

	public bool Find(string query)
	{
		char[] chars = query.ToCharArray();
		Node currentNode = _root;
		Node child = null;
		for (int counter = 0; counter < chars.Length; counter++)
		{
			child = currentNode.GetChild(chars[counter]);
			if (child == null)
				return false;
			currentNode = child;
		}

		return true;
	}

	public List<string> GetMatches(string query)
	{
		StringBuilder sbPrevious = new StringBuilder();
		char[] chars = query.ToCharArray();
		Node currentNode = _root;
		Node child = null;
		for (int counter = 0; counter < chars.Length; counter++)
		{
			if (counter < chars.Length - 1)
				sbPrevious.Append(chars[counter]);

			child = currentNode.GetChild(chars[counter]);
			if (child == null)
				break;
			currentNode = child;
		}

		subsequentStrings.Clear();

		GenerateSubsequentStrings(currentNode, sbPrevious.ToString());

		return subsequentStrings;
	}

	private void GenerateSubsequentStrings(Node node,
													string subsequentString)
	{
		if (node == null)
			return;

		subsequentString = subsequentString + node.Char;

		if (node.AWordEndsHere)
		{
			subsequentStrings.Add(subsequentString);
			//return;
		}

		foreach (var subnode in node.Subtree)
			GenerateSubsequentStrings(subnode, subsequentString);
	}
}
// Define other methods and classes here
class Node
{

	public char Char;
	public bool AWordEndsHere;
	public List<Node> Subtree;

	public Node(char c)
	{
		Char = c;
		Subtree = new List<Node>();
	}

	public Node(char c, bool wordends) : this(c)
	{
		AWordEndsHere = wordends;
	}

	public Node GetChild(char c)
	{
		if (Subtree.Count != 0)
			foreach (var node in Subtree)
				if (node.Char == c)
					return node;
		return null;
	}
}

public class StringListHelper
{
	public static List<string> InitializeList(string s, int count)
	{
		List<string> list = new List<string>();

		for (int i = 0; i < count; i++)
			list.Add(s);
		return list;
	}

	public static List<string> AddCharToList(List<string> list, char c)
	{
		List<string> temp = new List<string>();
		foreach (var elem in list)
		{
			temp.Add(elem + c);
		}
		return temp;
	}
}

