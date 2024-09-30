using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    [SerializeField] private float _startPointPositionY;
    [SerializeField] private float _minStartPointPositionX;
    [SerializeField] private float _maxStartPointPositionX;
    [SerializeField] private float _minStartPointPositionZ;
    [SerializeField] private float _maxStartPointPositionZ;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    public void PoolRelease(GameObject obj)
    {
        _pool.Release(obj);
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void ActionOnGet(GameObject obj)
    {
        float randomPositionX = Random.Range(_minStartPointPositionX, _maxStartPointPositionX);
        float randomPositionZ = Random.Range(_minStartPointPositionZ, _maxStartPointPositionZ);

        obj.transform.position = new Vector3(randomPositionX, _startPointPositionY, randomPositionZ);
        obj.SetActive(true);
    }
}
