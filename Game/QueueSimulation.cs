public class SimulateQueue
{
	public static void Main(String[] args)
	{

		Console.Write("\nHow many counters? ");
		int numCounters = Convert.ToInt32(Console.ReadLine());
		Console.Write("\nHow many customers? ");
		int numCustomers = Convert.ToInt32(Console.ReadLine());

		doSimulation(numCounters, numCustomers);
	} //end main

	public static void doSimulation(int counters, int customers)
	{
		int m, arriveTime, startServe, serveTime, waitTime;
		int[] depart = new int[counters + 1];
		for (int h = 1; h <= counters; h++) depart[h] = 0;
		Console.Write("\n");
		Console.WriteLine("{0,5}{1,8}{2,7} {3,6}{4,7}{5,8}{6,5}", "Customer", "Arrives", "Start Service", "Counter", "Sevice Time", "Departs Time", "Wait");
		arriveTime = 0;
		for (int h = 1; h <= customers; h++)
		{
			arriveTime += random(1, 5);
			m = smallest(depart, 1, counters);
			startServe = Math.Max(arriveTime, depart[m]);
			serveTime = random(3, 10);
			depart[m] = startServe + serveTime;
			waitTime = startServe - arriveTime;
			Console.Write("{0,5}{1,8}{2,7} {3,6}{4,7}{5,8}{6,5}\n",
			   h, arriveTime, startServe, m, serveTime, depart[m], waitTime);
		} //end for h
	} //end doSimulation

	public static int smallest(int[] list, int lo, int hi)
	{
		//returns the subscript of the smallest value from list[lo..hi]
		int h, k = lo;
		for (h = lo + 1; h <= hi; h++)
			if (list[h] < list[k]) k = h;
		return k;
	}

	public static int random(int m, int n)
	{
		//returns a random integer from m to n, inclusive
		Random rand = new Random();
		return rand.Next(m, n + 1);
	} //end random

} //end class SimulateQueue
