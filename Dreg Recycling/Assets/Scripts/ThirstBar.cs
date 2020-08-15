using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstBar : MonoBehaviour
{
    public void Update()
    {
        SetSize(FindObjectOfType<PlayerManager>().Thirst);
    }

    public void SetSize(float sizeNormalized)
    {
        gameObject.transform.localScale = new Vector3(sizeNormalized, 1f);
    }
}
