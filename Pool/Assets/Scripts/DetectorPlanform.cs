using UnityEngine;
using UnityEngine.Events;

public class DetectorPlanform : MonoBehaviour
{
    public event UnityAction CollisionHappened;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform planform))
        {
            CollisionHappened?.Invoke();
        }
    }
}
