using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalCreateText;
    [SerializeField] private TMP_Text _totalSpawnText;
    [SerializeField] private TMP_Text _activeObjectsText;

    [SerializeField] private GeneratorShape<Shape> _generatorShape;

    private void OnEnable()
    {
        _generatorShape.ShapeSpawned += ShowTotalSpawnCount;
        _generatorShape.ShapeCreated += ShowTotalCreatCount;
        _generatorShape.ShapeActivated += ShowActiveObjectsCount;
    }

    private void OnDisable()
    {
        _generatorShape.ShapeSpawned -= ShowTotalSpawnCount;
    }

    private void ShowTotalSpawnCount(int totalSpawned)
    {
        _totalSpawnText.text = totalSpawned.ToString();
    }

    private void ShowTotalCreatCount(int totalCreate)
    {
        _totalCreateText.text = totalCreate.ToString();
    }

    private void ShowActiveObjectsCount(int activeObjects)
    {
        _activeObjectsText.text = activeObjects.ToString();
    }
}
