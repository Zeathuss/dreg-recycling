using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private GameObject textObj;
    [SerializeField] private float fadeSpeed;

    private void Start()
    {
        textObj = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(textObj.activeSelf == true)
        {
            textObj.transform.position = new Vector2(transform.position.x, transform.position.y * 0.1f);

            Color objectColor = gameObject.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if(objectColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
