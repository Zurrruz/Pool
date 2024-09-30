using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public event UnityAction<ManagerObject> TimeOver;

    public void Run(ManagerObject managerObject)
    {
        StartCoroutine(StartTimer(managerObject));
    }

    private IEnumerator StartTimer(ManagerObject managerObject)
    {
        int time = Random.Range(_minValue, _maxValue);

        yield return new WaitForSeconds(time);

        TimeOver?.Invoke(managerObject);        
    }
}
