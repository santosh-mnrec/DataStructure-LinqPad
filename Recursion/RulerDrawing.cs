<Query Kind="Program" />

void Main()
{
	DrawRuler(1, 5);
}

public static void DrawRuler(int nInches, int majorLength)
{
	DrawLine(majorLength, 0); // draw inch 0 line and label
	for (int j = 1; j <= nInches; j++)
	{
		DrawInterval(majorLength - 1); // draw interior ticks for inch
		DrawLine(majorLength, j); // draw inch j line and label
	}
}

private static void DrawInterval(int centralLength)
{

	if (centralLength >= 1)
	{ // otherwise, do nothing
		DrawInterval(centralLength - 1); // recursively draw top interval
		DrawLine(centralLength); // draw center tick line (without label)
		DrawInterval(centralLength - 1); // recursively draw bottom interval
	}
}
private static void DrawLine(int tickLength, int tickLabel)
{
	for (int j = 0; j < tickLength; j++)

		Console.Write("-");
	if (tickLabel >= 0)
		Console.Write(" " + tickLabel);
	Console.Write("\n");
}
// Draws a line with the given tick length (but no label).

private static void DrawLine(int tickLength)
{
	DrawLine(tickLength, -1);
}
