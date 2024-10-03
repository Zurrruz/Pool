using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private LifeTimer _lifeTimer;

    public void StartTimer(Cube cube)
    {
        _lifeTimer.Run(cube);
    }
}
