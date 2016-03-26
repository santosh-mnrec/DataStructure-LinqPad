void Main()
{
	char[] post = new char[255];
	int n = InfixToPostFix.Convert(post);
	InfixToPostFix.printPostfix(post, n);
}

public class InfixToPostFix
{
	static Stack<char> S = new Stack<char>();
	public static void printPostfix(char[] post, int n)
	{
		Console.Write("\nThe postfix form is \n");
		for (int h = 0; h < n; h++) Console.Write("{0} ", post[h]);
		Console.Write("\n");
	} //end printPostfix

	public static bool IsEmpty()
	{
		return S.Count == 0;
	}
	public static int Convert(char[] post)
	{
	
		int h = 0;
		char c;
		Console.Write("Type an infix expression and press Enter\n");
		char token = GetToken();
		while (token != '0')
		{
			if (Char.IsDigit(token))
			post[h++] = token;
			else if (token == '(') 
			S.Push('(');
			else if (token == ')')
				while (!IsEmpty()  && (c = S.Pop()) != '(')
					post[h++] = c;
			else
			{
				while (!IsEmpty() && Precedence(S.Peek()) >= Precedence(token))
					post[h++] = S.Pop();
				S.Push(token);
			}
			token = GetToken();
		}
		while (!IsEmpty()) 
		post[h++] = S.Pop();
		return h;
	} //end readConvert
	public static int Precedence(char c)
	{
		if (c == '(') return 0;
		if (c == '+' || c == '-') return 3;
		if (c == '*' || c == '/') return 5;
		return -99; //error
	}
	public static int Precedence2(char c)
	{
		switch (c)
		{
			case '(': return 0;
			case '+':
			case '-': return 3;
			case '*':
			case '/': return 5;
			default:
				return -1;
		}//end switch

	} //end precedence
	public static char GetToken()
	{
		int n;
		while ((n = Console.Read()) == ' ') ; //read over blanks
		if (n == '\r' || n == '\n') return '0';
		//'\r' on Windows, MacOS and DOS; '\n' on Unix
		return (char)n;
	} //end getToken
}