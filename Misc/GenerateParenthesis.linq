<Query Kind="Program" />

void Main()
{
	generateParenthesis(2).Dump();
}

// Define other methods and classes here
List<string> generateParenthesis(int n)
{

	List<string> ans = new List<string>();
	if (n > 0) brackets(ans, "", n, 0);
	return ans;

}
void brackets(List<string> ans, string s, int openStock, int closeStock)
{
	if (openStock == 0 && closeStock == 0)
		ans.Add(s);

	if (openStock > 0)
		brackets(ans, s + "(", openStock - 1, closeStock + 1);
	if (closeStock > 0)
		brackets(ans, s + ")", openStock, closeStock - 1);
}