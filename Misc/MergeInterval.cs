



void Main()
{

	Interval int1 = new Interval(1, 3);
	Interval int2 = new Interval(7, 9);
	Interval int3 = new Interval(4, 6);
	Interval int4 = new Interval(10, 13);
	List<Interval> list = new List<Interval>();
	list.AddRange(new[] { int1, int2, int3, int4 });
	MergeIntervals m = new MergeIntervals();
	m.Merge(list).Dump();


}
public class Com : IComparer<Interval>
{
	public int Compare(Interval x, Interval y)
	{
		return x.Start - y.Start;
	}
}
public class Interval
{
	public int Start { get; set; }
	public int End { get; set; }
	public Interval(int x, int y)
	{
		this.Start = x;
		this.End = y;
	}

}
public class MergeIntervals
{

	public List<Interval> Merge(List<Interval> intervals)
	{
		List<Interval> result = new List<Interval>();
		if (intervals == null || intervals.Count() <= 1)
			return intervals;
		intervals.Sort(new Com());
		Interval prev = intervals[0];
		for (int i = 1; i < intervals.Count(); i++)

		{
			Interval curr = intervals[i];

			if (prev.End >= curr.Start)
			{
				// merged case
				Interval merged = new Interval(prev.Start, Math.Max(prev.End, curr.End));
				prev = merged;
			}
			else
			{
				result.Add(prev);
				prev = curr;
			}

		}
		return result;

	}


}
// Define other methods and classes here
