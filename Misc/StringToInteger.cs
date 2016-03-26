<Query Kind="Program" />

void Main()
{

	var result = ConvertToInt("-1321") + ConvertToInt("1321");
	result.Dump();

}

int ConvertToInt(string num)
{
	int result = 0;
	bool flag = false;
	if (num.Length == 0)
		return -1;
	if (num.IndexOf("-") != -1)
	{
		flag = true;
		num = num.Substring(1);
	}

	for (int i = 0; i < num.Length; i++)
		result = result * 10 + num[i] - '0';
	if (flag)
		return -result;
	return result;



}