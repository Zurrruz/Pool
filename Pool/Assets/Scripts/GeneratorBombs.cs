using UnityEngine;

public class GeneratorBombs : GeneratorShape<Shape>
{
    [SerializeField] private GeneratorCubes _spawnerCubes;

    protected override void Awake()
    {
        base.Awake();
    }

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
        Shape bomb = GetPooledObject();
        bomb.transform.position = transform.position;
        bomb.gameObject.SetActive(true);

        bomb.TimeOver += ReturnPool;
    }

    protected override void ReturnPool(Shape bomb)
    {
        base.ReturnPool(bomb);
        bomb.ResetParameters();

        bomb.TimeOver -= ReturnPool;
    }
}
