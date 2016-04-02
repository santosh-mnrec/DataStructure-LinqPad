void Main()
{
	CheckoutLine c = new CheckoutLine();
	c.Run();
	c.PrintReport(c.NumberServed, c.TotalWait, c.TotalLength);

}
public class CheckoutLine
{
	const double ARRIVAL_PROB = 0.05;
	const int MIN_SERVICE_TIME = 5;
	const int MAX_SERVICE_TIME = 15;
	const int SIMULATION_TIME = 20000;
	public int NumberServed { get; set; }
	public int TotalWait { get; set; }
	public int TotalLength { get; set; }
	public int RandomInteger(int min, int max)
	{
		Random rand = new Random();
		return rand.Next(min, max);
	}
	public bool RandonChance(double probability)
	{
		Random rand = new Random();
		var prob = rand.NextDouble();

		return probability > prob;



	}
	public void Run()
	{
		Queue<int> queue = new Queue<int>();
		int timeRemaining = 0;
		for (int i = 0; i < SIMULATION_TIME; i++)
		{
			if (RandonChance(ARRIVAL_PROB))
			{
				queue.Enqueue(i);
			}
			if (timeRemaining > 0)
			{
				timeRemaining--;
			}
			else if (queue.Count() != 0)
			{
				TotalWait += i - queue.Dequeue();
				NumberServed++;
				timeRemaining = RandomInteger(MIN_SERVICE_TIME, MAX_SERVICE_TIME);
			}
			TotalLength += queue.Count();

		}
	}
	public void PrintReport(int nServed, int totalWait, int totalLength)
	{
		Console.WriteLine("SIMULATION TIME :{0}", SIMULATION_TIME);
		Console.WriteLine("ARIVAL TIME :{0}", ARRIVAL_PROB);
		Console.WriteLine("MAX SERVICE TIME:{0}", MAX_SERVICE_TIME);
		Console.WriteLine("MIN SERVICE TIME:{0}", MIN_SERVICE_TIME);



		Console.WriteLine("Customer Served :{0}", nServed);

		var average = (double)totalWait/nServed;
		Console.WriteLine("Average Waiting Time:{0}", average);

		var qLength = (double)totalLength / SIMULATION_TIME;
		Console.WriteLine("Average Queue Length:{0}", qLength);

	}

}
