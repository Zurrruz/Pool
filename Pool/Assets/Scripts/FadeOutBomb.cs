using System.Collections;
using UnityEngine;

public class FadeOutBomb : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public void Vanish(float fadeTime)
    {
        StartCoroutine(FadeOut(fadeTime));
    }

    private IEnumerator FadeOut(float fadeTime)
    {
        float elapsedTime = 0f;

        Color color = _renderer.material.color;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime);
            _renderer.material.color = color;

            yield return null;
        }
    }
}
