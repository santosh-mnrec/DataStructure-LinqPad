<Query Kind="Program" />

void Main()
{

}

public interface IFilter<T>
{
	T Execute(T input)
    void Register(IFilter<T> filter);
}

public interface IFilterChain<T>
{
	void Execute(T input);
	IFilterChain<T> Register(IFilter<T> filter);

}

public class PipeLine<T> : IFilterChain<T>
{
	private IFilter<T> _root;
	public void Execute(T input)
	{
		_root.Execute(input);

	}
	public IFilterChain<T> Register(IFilter<T> filter)
	{
		if (_root == null)
		{
			_root = filter;
		}
		else
		{

			_root.Register(filter);
		}
		return this;
	}

}
public abstract class FilterBase<T> : IFilter<T>
{
	private IFilter<T> _next;
	protected abstract T Process(T input);
	public T Execute(T input)
	{
		T val = Process(input);
		if (_next != null)
			val = _next.Execute(val);
		return val;
	}
	public void Register(IFilter<T> filter)
	{
		if (_next == null)
			_next = filter;
		else
			_next.Register(filter);
	}

}
