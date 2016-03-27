public class BottleCaps
{
	static int MaxSim = 20;
	static int MaxLetters = 5;
	public static void Main(String[] args)
	{
	
		int sim, capsThisSim, totalCaps = 0;
		Console.Write("\nSimulation  Caps collected\n\n");
		for (sim = 1; sim <= MaxSim; sim++)
		{
			capsThisSim = doOneSimulation();
			Console.Write("{0,6} {1,16}\n", sim, capsThisSim);
			totalCaps += capsThisSim;
		}
		Console.Write("\nAverage caps per simulation: {0}\n", totalCaps / MaxSim);
	} //end main

	public static int doOneSimulation()
	{
		bool[] cap = new bool[MaxLetters];
		for (int j = 0; j < MaxLetters; j++) cap[j] = false;
		int numCaps = 0;
		while (!mango(cap))
		{
			int c = random(1, 21);
			if (c <= 8) cap[0] = true;
			else if (c <= 13) cap[1] = true;
			else if (c <= 16) cap[2] = true;
			else if (c <= 19) cap[3] = true;
			else cap[4] = true;
			numCaps++;
		} //end while
		return numCaps;
	} //end doOneSimulation

	public static bool mango(bool[] cap)
	{
		for (int j = 0; j < MaxLetters; j++)
			if (cap[j] == false) return false;
		return true;
	} //end mango
static Random rand=new Random();
	public static int random(int m, int n)
	{
		
		return rand.Next(m,n);
	} //end random

} //end class BottleCaps
