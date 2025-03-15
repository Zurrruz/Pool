using UnityEngine;

public class Cube : Shape
{
    [SerializeField] private ColorChanger _cubeColorChanger;
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

    public override void OnLifeEnd()
    {
        ResetParameters();
    }

    private  void ResetParameters()
    {
        _cubeColorChanger.Reset();

        CanTouch = true;
    }

    private void EstablishNewParameters()
    {
        if (CanTouch)
        {
            PaintRandom();
            PreventTimerStarted();
            StartCoroutine(LifeTimer());
        }
    }

    private void PreventTimerStarted()
    {
        CanTouch = false;
    }

    private void PaintRandom()
    {
        _cubeColorChanger.PaintRandom();
    }
}
