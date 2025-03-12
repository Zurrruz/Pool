using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorShape<T> : MonoBehaviour where T : Shape
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    private int _totalCreated = 0;
    private int _totalSpawned = 0;
    private int _activeObjects = 0;

    public event Action<int> ShapeActivated;
    public event Action<int> ShapeSpawned;
    public event Action<int> ShapeCreated;

    protected virtual void Awake()
    {
        _pool = new Queue<T>();
    }

    protected virtual void ReturnPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);

        _activeObjects--;
        ShapeActivated?.Invoke(_activeObjects);
    }

    protected T GetPooledObject()
    {
        if(_pool.Count > 0)
        {
            _totalSpawned++;
            ShapeSpawned?.Invoke(_totalSpawned);

            _activeObjects++;
            ShapeActivated?.Invoke(_activeObjects);

            return _pool.Dequeue();
        }

        T obj = Instantiate(_prefab, transform);

        _activeObjects++;
        ShapeActivated?.Invoke(_activeObjects);

        _totalSpawned++;
        ShapeSpawned?.Invoke(_totalSpawned);

        _totalCreated++;
        ShapeCreated?.Invoke(_totalCreated);

        return obj;
    }
}
