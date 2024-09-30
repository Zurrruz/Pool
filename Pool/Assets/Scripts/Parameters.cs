using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] private Ñoloration _colorScheme;

    private bool _canTtouch = true;

    public bool CanTouch => _canTtouch;

    public void Default()
    {
        _colorScheme.Default();

        gameObject.SetActive(false);

        _canTtouch = true;
    }

    public void PreventTimerStarted()
    {
        _canTtouch = false;
    }
}
