<Query Kind="Program" />

void Main()
{
	intToRoman(101).Dump();
}
static string intToRoman(int num)
{

	var result = new StringBuilder();
	int newnum;
	int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
	string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
	for (int i = 0; i < values.Length - 1; i++)
	{

		while (num >= values[i])
		{
			num = num - values[i];
			result.Append(symbols[i]);
		}

	}
	return result.ToString();
}
// Define other methods and classes here