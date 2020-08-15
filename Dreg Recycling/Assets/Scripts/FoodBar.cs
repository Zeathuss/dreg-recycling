using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBar : MonoBehaviour
{
    public void Update()
    {
        SetSize(FindObjectOfType<PlayerManager>().Hunger);
    }

    public void SetSize(float sizeNormalized)
    {
        gameObject.transform.localScale = new Vector3(sizeNormalized, 1f);
    }
}
