static int orgCount = 0;
void Main()
{
	int m = 5;
	int n = 7;
	OrgCount o = new OrgCount();
	int[,] G = new[,] {
			{0 , 1,  0 , 1 , 1,  1,  0},
			{0,  0 , 1 , 1 ,  0 , 0 , 0},
			{1 , 1 , 0,  1 , 0 , 0,  1},
			{1  ,0  ,1 , 0 , 0 , 1  ,1},
			{1,  1 , 0 , 0 , 0 , 1 , 0}
	};
	for (int i = 0; i < m; i++)
		for (int j = 0; j < n; j++)
			if (G[i, j] == 1)
			{
				orgCount++;
				o.FindOrg(G, i, j, m, n);
			}
	o.PrintOrg(G, m, n);
}

public class OrgCount
{

	public void FindOrg(int[,] G, int i, int j, int m, int n)
	{
		if (i < 0 || i >= m || j < 0 || j >= n)
			return; //outside of grid
		if (G[i,j] == 0 || G[i,j] > 1) return; //no cell or cell already seen
												 // else G[i][j] = 1;
		G[i,j] = orgCount + 1;       //so that this 1 is not considered again
		FindOrg(G, i - 1, j, m, n);  //North
		FindOrg(G, i, j + 1, m, n);  //East
		FindOrg(G, i + 1, j, m, n);  //South
		FindOrg(G, i, j - 1, m, n);  //West

	}
	public void PrintOrg(int[,] G, int m, int n)
	{
		Console.Write("\nNumber of organisms = {0}\n", orgCount);
		Console.Write("\nPosition of organisms are shown below\n\n");
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
				if (G[i, j] > 1) Console.Write("{0} ", G[i, j] - 1);
				//organism labels are one more than they should be
				else
					Console.Write("{0} ", G[i, j]);
			Console.WriteLine();
		}
	} //end printOrg

}
