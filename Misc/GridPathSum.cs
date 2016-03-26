<Query Kind="Program" />

/*
Minimum Path Sum
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
Note: You can only move either down or right at any point in time.

Solution :  

This can be done by in place dynamic programming. The idea is to replace matrix[i][j] values with the minimum value that can be achieved (among two paths) to reach matrix[i][j].
We can reach matrix[i][j] through one of 
matrix[i-1][j] or
matrix[i][j-1]
We record the minimum of these two at matrix[i][j].
*/

void Main()
{
	var grid = new[,]{
		{1,2,1,1},
		{1,9,1,1},
		{1,9,1,1}

	};
	minPathSum(grid).Dump();

}
int minPathSum(int[,] grid)
{
	int row = grid.GetLength(0);
	int col = grid.GetLength(1);
	int i = 0, j = 0;
	for (i = 0; i < row; i++)
	{
		for (j = 0; j < col; j++)
		{
			if (i != 0 && j != 0)
			{
				if (i == 0 && j > 0)
					grid[i, j] += grid[i, j - 1];
				else if (i > 0 && j == 0)
					grid[i, j] += grid[i - 1, j];
				else
					grid[i, j] += Math.Min(grid[i, j - 1], grid[i - 1, j]);
			}
		}
	}
	grid.Dump();
	return grid[i - 1, j - 1];
}
// Define other methods and classes here
