<Query Kind="Program" />

void Main()
{
		DirSearch(@"C:\temp").Dump();
}

static int DirSearch(string sDir)
{
	int size=0;
	try
	{
		foreach (string d in Directory.GetDirectories(sDir))
		{
			foreach (string f in Directory.GetFiles(d))
			{
				Console.WriteLine(f);
			}
			DirSearch(d);
		}
	}
	catch (System.Exception excpt)
	{
		Console.WriteLine(excpt.Message);
	}
	return size;
	
}
