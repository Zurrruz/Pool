using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Coloration : MonoBehaviour
{
    [SerializeField] private Color _default;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Reset()
    {
        _renderer.material.color = _default;
    }

    public void PaintRandom()
    {
        _renderer.material.color = new Color(
            Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f));
    }
}
