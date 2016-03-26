<Query Kind="Program" />

void Main()
{
	Sub(new[] { 1, 2, 3}.ToList()).Dump();
}

public List<List<int>> Sub(List<int> set)
{
	var all = new List<List<int>>();
	int max = 1 << set.Count;
	for (int i = 0; i < max; i++)
	{
		List<int> subset = new List<int>();
		int k = i;
		int index = 0;
		while (k > 0)
		{
			if ((k & 1) > 0)
			{
				subset.Add(set[index]);
			}
			k >>= 1;
			index++;

		}
		all.Add(subset);

	}
	return all;

}