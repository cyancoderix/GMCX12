namespace CyanDevelopers.GMCX12.Core.Handlers;

public class DataHandler(int pools, int defaultSize) {
	readonly object?[] data = new object[pools];

	public void Add<T>(int index, T value, int? poolSize = null)
	{
		foreach (object? pool in data)
			if (pool is T[] correct) {
				correct[index] = value;
				return;
			}
		for (int i=0; i<data.Length; i++)
			if (data[i] == null) { 
				T[] pool = new T[poolSize ?? defaultSize]; 
				pool[index] = value;
				data[i] = pool;
				return;
			}
		throw new OverflowException();
	}

	public ref T Get<T>(int index)
	{
		foreach (object? pool in data)
			if (pool is T[] correct)
				return ref correct.AsSpan()[index];
		throw new NullReferenceException();
	}
}
