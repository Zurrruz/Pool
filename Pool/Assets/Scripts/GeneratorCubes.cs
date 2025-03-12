using System;
using System.Collections;
using UnityEngine;

public class GeneratorCubes : GeneratorShape<Shape> 
{
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private Vector3 _spawnArea;

    private WaitForSeconds _delay;

    public event Action<Transform> ReturnedCube;

    protected override void Awake()
    {
        base.Awake();
        _delay = new WaitForSeconds(_spawnInterval);
    }

    private void Start()
    {
        StartCoroutine(StartRainCubs());
    }

    private IEnumerator StartRainCubs()
    {
        while (enabled)
        {
            Shape cube = GetPooledObject();
            cube.transform.position = GetRandomPosition();
            cube.gameObject.SetActive(true);
            cube.ResetParameters();

            cube.TimeOver += ReturnPool;

            yield return _delay;
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            UnityEngine.Random.Range(-_spawnArea.x, _spawnArea.x),
            _spawnArea.y,
            UnityEngine.Random.Range(-_spawnArea.z, _spawnArea.z)
        );
    }

    protected override void ReturnPool(Shape cube)
    {
        base.ReturnPool(cube);

        cube.TimeOver -= ReturnPool;

        ReturnedCube?.Invoke(cube.transform);
    }
}