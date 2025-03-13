using System.Collections.Generic;
using UnityEngine;

public class Bomb : Shape
{
    [SerializeField] private FadeOutBomb _fadeOutBomb;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        StartCoroutine(LifeTimer());
        StartFade();
    }

    public override void ResetParameters()
    {
        Explode();
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubs = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody !=null)
                cubs.Add(hit.attachedRigidbody);

        return cubs;
    }

    private void StartFade()
    {
        _fadeOutBomb.Vanish(LifeTime);
    }
}
