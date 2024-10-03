using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public event UnityAction<Cube> TimeOver;

    public void Run( Cube cube)
    {
        StartCoroutine(StartTimer(cube));
    }

    private IEnumerator StartTimer(Cube cube)
    {
        int time = Random.Range(_minValue, _maxValue);

        yield return new WaitForSeconds(time);

        TimeOver?.Invoke(cube);
    }
}
