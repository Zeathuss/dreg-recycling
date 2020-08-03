using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SellBottles : MonoBehaviour
{
    [SerializeField] private int Bottles;
    [SerializeField] private int glassBottles;
    [SerializeField] private GameObject sellingPanel;

    

    private void Update()
    {
        if (GameObject.Find("Player"))
        {
            Bottles = FindObjectOfType<PlayerManager>().Bottles;
            glassBottles = FindObjectOfType<PlayerManager>().glassBottle;
            sellingPanel = FindObjectOfType<ButtonManager>().sellingPanel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Recycling")
        {
            sellingPanel.SetActive(true);
        }
    }

    public void sellBottles()
    {
        FindObjectOfType<PlayerManager>().Money += (Bottles * 0.50f);
        FindObjectOfType<PlayerManager>().Bottles -= Bottles;
    }

    public void sellGlassBottles()
    {
        FindObjectOfType<PlayerManager>().Money += (glassBottles * 2.50f);
        FindObjectOfType<PlayerManager>().glassBottle -= glassBottles;
    }
}
