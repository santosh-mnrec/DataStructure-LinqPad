<Query Kind="Program" />

void Main()
{
	RemoveV("recurse").Dump();

}
public static void printSeries(int n1, int n2)
{
	if (n1 == n2)
	{
		Console.WriteLine(n2);
	}
	else
	{
		Console.WriteLine(n1 + ", ");
		printSeries(n1 + 1, n2);
	}
}
static int count = 0;
public static int numOccur(char ch, String str)
{
	if (str == null || str.Equals(""))
	{
		return 0;
	}

	if (str[0] == ch)
	{
		count++;
	}
	numOccur(ch, str.Substring(1));
	return count;
}
static string result = "";
public static string RemoveV(string str)
{

	if (str == null || str.Equals(""))
	{
		return string.Empty;
	}
	if (str[0] == 'a' || str[0] == 'o' || str[0] == 'u' || str[0] == 'e' || str[0] == 'i')
	{
		RemoveV(str.Substring(1));
	}
	else
	{
		result += str[0].ToString();
		RemoveV(str.Substring(1));
	}

	return result;


}
// Define other methods and classes here
