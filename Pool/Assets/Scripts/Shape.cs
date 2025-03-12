using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shape : MonoBehaviour
{
    [SerializeField] private int _minLifeTime;
    [SerializeField] private int _maxLifeTime;

    private WaitForSeconds _time;

    protected int _lifeTime;

    public event UnityAction<Shape> TimeOver;

    private void Awake()
    {
        _lifeTime = Random.Range(_minLifeTime, _maxLifeTime);
        _time = new WaitForSeconds(_lifeTime);
    }

    public abstract void ResetParameters();

    protected IEnumerator StartTimer()
    {
        yield return _time;

        TimeOver?.Invoke(this);                   
    }
}
