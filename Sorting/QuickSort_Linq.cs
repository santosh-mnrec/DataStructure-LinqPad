
void Main()
{
	var r = new[] { 1, -1, -2, 22};
	var r1=QSLinq(r);
	r1.Dump();
}
public static IEnumerable<int> QSLinq(IEnumerable<int> _items)
{
	if (_items.Count() <= 1)
		return _items;

	var _pivot = _items.First();

	var _less = from _item in _items where _item < _pivot select _item;
	var _same = from _item in _items where _item == _pivot select _item;
	var _greater = from _item in _items where _item > _pivot select _item;

	return QSLinq(_less).Concat(QSLinq(_same)).Concat(QSLinq(_greater));
}
static List<int> RandomList(int size)
{
	List<int> ret = new List<int>(size);
	Random rand = new Random(1);
	for (int i = 0; i < size; i++)
	{
		ret.Add(rand.Next(size));
	}
	return ret;
}
