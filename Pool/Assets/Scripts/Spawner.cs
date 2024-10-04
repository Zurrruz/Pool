using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    [SerializeField] private float _startPointPositionY;
    [SerializeField] private float _minStartPointPositionX;
    [SerializeField] private float _maxStartPointPositionX;
    [SerializeField] private float _minStartPointPositionZ;
    [SerializeField] private float _maxStartPointPositionZ;    

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => LaunchesObject(obj),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);        
    }

    private void Start()
    {
        StartCoroutine(StartRainCubes());
    }

    public void ReturnBackPool(Cube obj)
    {
        obj.ResetParameters();
        obj.TimeOver -= ReturnBackPool;

        _pool.Release(obj);
    }

    private IEnumerator StartRainCubes()
    {
        GetCube();

        yield return new WaitForSeconds(_repeatRate);

        StartCoroutine(StartRainCubes());   
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void LaunchesObject(Cube obj)
    {
        float randomPositionX = Random.Range(_minStartPointPositionX, _maxStartPointPositionX);
        float randomPositionZ = Random.Range(_minStartPointPositionZ, _maxStartPointPositionZ);

        obj.transform.position = new Vector3(randomPositionX, _startPointPositionY, randomPositionZ);
        obj.gameObject.SetActive(true);

        obj.TimeOver += ReturnBackPool;
    }
}
