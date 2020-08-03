using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningShop : MonoBehaviour
{
    public GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            shopPanel.SetActive(true);
        }
    }

    public void closeShop()
    {
        shopPanel.SetActive(false);
    }
}
