<Query Kind="Program" />

/*
Write a program to print all the LEADERS in the array. An element is leader if it is greater than all the elements to its right side. And the rightmost element is always a leader. For example int the array {16, 17, 4, 3, 5, 2}, leaders are 17, 5 and 2.
*/
void Main()
{
	var arr = new[] { 1, 2, 11, 5, 6 };
	printLeader2(arr, arr.Length);
}

void printLeader2(int[] arr, int n)
{
	int max_from_right = arr[n - 1];
	max_from_right.Dump("Max From Right");
	for (int i = n - 2; i >= 0; i--)
	{
		if (arr[i] > max_from_right)
		{
			arr[i].Dump(" ");
			max_from_right = arr[i];
		}
	}
}
// Define other methods and classes here