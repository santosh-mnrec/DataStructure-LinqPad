<Query Kind="Program" />

void Main()
{
	var matrix = new[,]{
		{ 1, 2, 3 },
		{ 4, 0, 6 },
		{ 7, 8, 9 }
	};
	spiralOrder(matrix).Dump();

}
public List<int> spiralOrder(int[,] matrix)
{
	List<int> result = new List<int>();

	if (matrix == null || matrix.Length == 0) return result;

	int m = matrix.GetLength(0);
	int n = matrix.GetLength(1);

	int x = 0;
	int y = 0;

	while (m > 0 && n > 0)
	{

		//if one row/column left, no circle can be formed
		if (m == 1)
		{
			for (int i = 0; i < n; i++)
			{
				result.Add(matrix[x, y++]);
			}
			break;
		}
		else if (n == 1)
		{
			for (int i = 0; i < m; i++)
			{
				result.Add(matrix[x++, y]);
			}
			break;
		}

		//below, process a circle

		//top - move right
		for (int i = 0; i < n - 1; i++)
		{
			result.Add(matrix[x, y++]);
		}

		//right - move down
		for (int i = 0; i < m - 1; i++)
		{
			result.Add(matrix[x++, y]);
		}

		//bottom - move left
		for (int i = 0; i < n - 1; i++)
		{
			result.Add(matrix[x, y--]);
		}

		//left - move up
		for (int i = 0; i < m - 1; i++)
		{
			result.Add(matrix[x--, y]);
		}

		x++;
		y++;
		m = m - 2;
		n = n - 2;
	}

	return result;
}
// Define other methods and classes here
