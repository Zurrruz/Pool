using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Ñoloration : MonoBehaviour
{
    [SerializeField] private Color _default;
    private Renderer _renderer;

    private bool _canChangeColor = true;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Plane"))
        {
            if (_canChangeColor)
            {
                PaintRandom();
                _canChangeColor = false;
            }
        }
    }

    public void Default()
    {
        _renderer.material.color = _default;

        _canChangeColor = true;
    }

    private void PaintRandom()
    {
        _renderer.material.color = new UnityEngine.Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f));
    }
}
