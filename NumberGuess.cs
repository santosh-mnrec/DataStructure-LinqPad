public static void Main(String[] args)
{
	
	Console.WriteLine("\nI have thought of a number from 1 to 100.\n");
	Console.WriteLine("Try to guess what it is.\n\n");
	int answer = new Random().Next(1, 100);

	Console.WriteLine("Your guess? ");
	int guess = Convert.ToInt32(Console.ReadLine());
	while (guess != answer && guess != 0)
	{
		if (guess < answer) Console.WriteLine("Too low\n");
                 else Console.WriteLine("Too high\n");
		Console.WriteLine("Your guess? ");
		guess = Convert.ToInt32(Console.ReadLine());
	}
	if (guess == 0) Console.WriteLine("Sorry, answer is %d\n", answer);
              else Console.WriteLine("Congratulations, you've got it!\n");
} //end main
