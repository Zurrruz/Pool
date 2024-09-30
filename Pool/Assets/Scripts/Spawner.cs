using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ManagerObject _prefab;
    [SerializeField] private LifeTimer _lifeTimer;

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    [SerializeField] private float _startPointPositionY;
    [SerializeField] private float _minStartPointPositionX;
    [SerializeField] private float _maxStartPointPositionX;
    [SerializeField] private float _minStartPointPositionZ;
    [SerializeField] private float _maxStartPointPositionZ;    

    private ObjectPool<ManagerObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<ManagerObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => LaunchesObject(obj),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);        
    }

    private void Start()
    {
        StartCoroutine(StartRainCubes());
    }

    private void OnEnable()
    {
        _lifeTimer.TimeOver += PoolRelease;
    }

    private void OnDisable()
    {
        _lifeTimer.TimeOver -= PoolRelease;
    }

    public void PoolRelease(ManagerObject obj)
    {
        obj.ResetParameters();
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

    private void LaunchesObject(ManagerObject obj)
    {
        float randomPositionX = Random.Range(_minStartPointPositionX, _maxStartPointPositionX);
        float randomPositionZ = Random.Range(_minStartPointPositionZ, _maxStartPointPositionZ);

        obj.transform.position = new Vector3(randomPositionX, _startPointPositionY, randomPositionZ);
        obj.gameObject.SetActive(true);
    }
}
