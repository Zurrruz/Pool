using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shape : MonoBehaviour
{
    [SerializeField] private int _minLifeTime;
    [SerializeField] private int _maxLifeTime;

    private WaitForSeconds _time;

    protected int LifeTime;

    public event UnityAction<Shape> TimeOver;

    private void Awake()
    {
        LifeTime = Random.Range(_minLifeTime, _maxLifeTime + 1);
        _time = new WaitForSeconds(LifeTime);
    }

    public abstract void ResetParameters();

    protected IEnumerator LifeTimer()
    {
        yield return _time;

        TimeOver?.Invoke(this);                   
    }
}
