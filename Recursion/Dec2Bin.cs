

void Main()
{
Dec2Bin(8);
}

void Dec2Bin(int n)
{
	if(n==0)
		return;
	Dec2Bin(n/2);
	Console.Write(n%2);
	


}