using System.Collections;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Parameters parameters))
        {
            if (parameters.CanTouch)
            {
                StartCoroutine(Timer(parameters));
                parameters.PreventTimerStarted();
            }
        }
    }

    private IEnumerator Timer(Parameters parameters)
    {
        int time = Random.Range(_minValue, _maxValue);

        yield return new WaitForSeconds(time);

        parameters.gameObject.SetActive(false);

        _spawner.PoolRelease(parameters.gameObject);

        parameters.Default();
    }
}
