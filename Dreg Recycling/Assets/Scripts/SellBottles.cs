using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBottles : MonoBehaviour
{
    private int Bottles;
    private int glassBottles;
    private GameObject sellingPanel;

    private void Awake()
    {
        if (GameObject.Find("Player"))
        {
            Bottles = GameObject.Find("Player").GetComponent<PlayerManager>().Bottles;
            glassBottles = GameObject.Find("Player").GetComponent<PlayerManager>().glassBottle;
            sellingPanel = GameObject.Find("ButtonManager").GetComponent<ButtonManager>().sellingPanel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sellingPanel.SetActive(false);
    }

    public void sellBottles()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += (Bottles * 0.50f);
    }

    public void sellGlassBottles()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += (glassBottles * 2.50f);
    }
}
