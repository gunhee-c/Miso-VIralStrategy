using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fade
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Call this method to fade in
    public void FadeIn()
    {
        StartCoroutine(DoFade(1, 0));
    }

    // Call this method to fade out
    public void FadeOut()
    {
        StartCoroutine(DoFade(0, 1));
    }

    private IEnumerator DoFade(float startAlpha, float endAlpha)
    {
        float counter = 0f;

        while (counter < fadeDuration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, counter / fadeDuration);
            yield return null;
        }
    }
}
