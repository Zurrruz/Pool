using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [SerializeField] private Coloration _colorScheme;
    [SerializeField] private DetectorPlanform _detectorPlanform;

    [SerializeField] private int _minLifeTime;
    [SerializeField] private int _maxLifeTime;

    public event UnityAction<Cube> TimeOver;

    public bool CanTouch { get; private set; } = true;

    private void OnEnable()
    {
        _detectorPlanform.CollisionHappened += EstablishNewParameters;
    }
    private void OnDisable()
    {
        _detectorPlanform.CollisionHappened -= EstablishNewParameters;
    }

    public void ResetParameters()
    {
        _colorScheme.Reset();

        gameObject.SetActive(false);

        CanTouch = true;
    }

    private void EstablishNewParameters()
    {
        if (CanTouch)
        {
            PaintRandom();
            PreventTimerStarted();
            StartCoroutine(StartTimer());
        }
    }

    private IEnumerator StartTimer()
    {
        int time = Random.Range(_minLifeTime, _maxLifeTime);

        yield return new WaitForSeconds(time);

        TimeOver?.Invoke(this);
    }

    private void PreventTimerStarted()
    {
        CanTouch = false;
    }

    private void PaintRandom()
    {
        _colorScheme.PaintRandom();
    }
}
