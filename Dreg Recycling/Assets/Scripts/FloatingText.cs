using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;

    private float fadeOutTime = 5;

    private void Awake()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private void Update()
    {
            if (gameObject.activeSelf == true)
            {
                transform.Translate(transform.up * 0.1f * Time.deltaTime);

            TMP_Text text = GetComponent<TMP_Text>();

            if (text.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    private IEnumerator FadeOutRoutine()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        Color originalColor = text.color;

        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }

}
