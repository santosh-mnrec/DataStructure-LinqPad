void Main()
{

	Console.Write("\nNumber of matches on the table? ");

	int remain = Convert.ToInt32(Console.ReadLine());
	Console.Write("Maximum pickup per turn? ");
	int maxPick = Convert.ToInt32(Console.ReadLine());
	Nim.PlayGame(remain, maxPick);
}

public class Nim
{

	public static void PlayGame(int remain, int maxPick)
	{

		int userPick;

		Console.Write("\nMatches remaining: {0}\n", remain);
		while (true)
		{ //do forever...well, until the game ends
			do
			{
				Console.Write("Your turn: ");
				userPick = Convert.ToInt32(Console.ReadLine());
				if (userPick > remain)
					Console.Write("Cannot pick up more than {0}\n", Math.Min(remain, maxPick));
				else if (userPick < 1 || userPick > maxPick)
					Console.Write("Invalid: must be between 1 and {0}\n", maxPick);
			} while (userPick > remain || userPick < 1 || userPick > maxPick);

			remain = remain - userPick;
			Console.Write("Matches remaining: {0}\n", remain);
			if (remain == 0)
			{
				Console.Write("You lose!!\n"); return;
			}
			if (remain == 1)
			{
				Console.Write("You win!!\n"); return;
			}
			int compPick = BestPick(remain, maxPick);
			Console.Write("I pick up {0}\n", compPick);
			remain = remain - compPick;
			Console.Write("Matches remaining: {0}\n", remain);
			if (remain == 0)
			{
				Console.Write("You win!!\n");
				return;
			}
			if (remain == 1)
			{
				Console.Write("I win!!\n");
				return;
			}
		} //end while (true)
	} //end playGame

	public static int BestPick(int remain, int maxPick)
	{
		if (remain <= maxPick) return remain - 1; //put user in losing position
		int r = remain % (maxPick + 1);
		if (r == 0) return maxPick;               //put user in losing position
		if (r == 1) return Random(1, maxPick);    //computer in losing position
		return r - 1;                             //put user in losing position
	}                                            //end bestPick

	public static int Random(int m, int n)
	{
		Random rand = new Random();

		return rand.Next(m, n);
	}

}
