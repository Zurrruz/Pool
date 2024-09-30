using UnityEngine;

public class ManagerObject : MonoBehaviour
{
    [SerializeField] private Coloration _colorScheme;

    public bool CanTouch { get; private set; } = true;

    public void ResetParameters()
    {
        _colorScheme.Reset();

        gameObject.SetActive(false);

        CanTouch = true;
    }

    public void PreventTimerStarted()
    {
        CanTouch = false;
    }

    public void PaintRandom()
    {
        _colorScheme.PaintRandom();
    }
}
