using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
            if (_cube.CanTouch)
            {
                _cube.PaintRandom();
                _cube.PreventTimerStarted();

                plane.StartTimer(_cube);
            }
        }
    }
}
