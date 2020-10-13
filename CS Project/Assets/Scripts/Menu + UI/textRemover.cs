using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class textRemover : MonoBehaviour
{
    public float fadeOutTime;

    void Start()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine() // this fades out the text over the set amount of secconds
    {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
}