using UnityEngine;

public class GeneratorBombs : GeneratorShape
{
    [SerializeField] private GeneratorCubes _spawnerCubes;

    private void OnEnable()
    {
        _spawnerCubes.ReturnedCube += SpawnBomb;
    }

    private void OnDisable()
    {
        _spawnerCubes.ReturnedCube -= SpawnBomb;
    }

    private void SpawnBomb(Transform transform)
    {
        SpawnObject(transform.position);
    }
}
