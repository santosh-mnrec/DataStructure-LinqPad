<Query Kind="Program" />

void Main()
{
	Reverse("santosh").Dump();
}

public string Reverse(string str)
{
		if(str.Length==1)
			return str;
		string result= str[str.Length-1]+Reverse(str.Substring(0,str.Length-1));
		return result;
}
