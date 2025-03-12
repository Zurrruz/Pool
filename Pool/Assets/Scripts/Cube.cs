using UnityEngine;

public class Cube : Shape
{
    [SerializeField] private Coloration _colorScheme;
    [SerializeField] private DetectorPlanform _detectorPlanform;

    public bool CanTouch { get; private set; } = true;

    private void OnEnable()
    {
        _detectorPlanform.CollisionHappened += EstablishNewParameters;
    }

    private void OnDisable()
    {
        _detectorPlanform.CollisionHappened -= EstablishNewParameters;
    }

    public override void ResetParameters()
    {
        _colorScheme.Reset();

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

    private void PreventTimerStarted()
    {
        CanTouch = false;
    }

    private void PaintRandom()
    {
        _colorScheme.PaintRandom();
    }
}
