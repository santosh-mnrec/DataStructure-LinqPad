<Query Kind="Program" />

void Main()
{
	majorityElement(new[] { 3, 1, 1, 1 });
}
void majorityElement(int[] arr)
{
	int size = arr.Length - 1;
	int[] count = new int[size + 1];
	for (int i = 0; i < size; i++)
	{
		++count[arr[i]];

	}
	for (int j = 0; j < 100; j++)
		if (count[j] > size / 2)
		{
			j.Dump("Majorty");
			return;
		}
	"NONE".Dump();
}
// Define other methods and classes here
