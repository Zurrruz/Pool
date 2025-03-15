using System;
using System.Collections.Generic;

public class Pool<T> where T : class
{
    private  Queue<T> _pool = new();
    private  Func<T> _createFunc;

    public int CountCreated { get; private set; } = 0;

    public Pool(Func<T> createFunc)
    {
        _createFunc = createFunc;
    }

    public T Get()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();

        CountCreated++;

        return _createFunc();
    }

    public void ReturnPool(T obj)
    {
        _pool.Enqueue(obj);
    }
}
