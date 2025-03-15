using System;
using UnityEngine;

public class GeneratorShape : MonoBehaviour
{
    [SerializeField] private Shape _prefab;

    private Pool<Shape> _pool;

    private int _totalCreated = 0;
    private int _totalSpawned = 0;
    private int _activeObjects = 0;

    public event Action<int> ShapeActivated;
    public event Action<int> ShapeSpawned;
    public event Action<int> ShapeCreated;

    protected virtual void Awake()
    {
        _pool = new Pool<Shape>(createFunc: () => Instantiate(_prefab, transform));
    }

    protected virtual void EndLifecycleObject(Shape obj) 
    {
        obj.OnLifeEnd();
    }

    private void ReturnPool(Shape obj)
    {
        EndLifecycleObject(obj);
        
        obj.gameObject.SetActive(false);
        obj.TimeOver -= ReturnPool;

        _pool.ReturnPool(obj);

        _activeObjects--;
        ShapeActivated?.Invoke(_activeObjects);
    }

    protected void SpawnObject(Vector3 position)
    {
        Shape obj = _pool.Get();
        
        obj.transform.position = position;
        obj.gameObject.SetActive(true);
        obj.TimeOver += ReturnPool;

        _totalSpawned++;
        ShapeSpawned?.Invoke(_totalSpawned);

        _activeObjects++;
        ShapeActivated?.Invoke(_activeObjects);

        _totalCreated = _pool.CountCreated;
        ShapeCreated?.Invoke(_totalCreated);
    }
}
