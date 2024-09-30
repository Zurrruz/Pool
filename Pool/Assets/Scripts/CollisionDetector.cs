using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private LifeTimer _lifeTimer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ManagerObject managerObject))
        {
            if (managerObject.CanTouch)
            {
                managerObject.PaintRandom();
                managerObject.PreventTimerStarted();
                _lifeTimer.Run(managerObject);
            }
        }
    }
}
