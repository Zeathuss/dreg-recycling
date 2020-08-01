﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForBottles : MonoBehaviour
{
    [SerializeField] private int chanceToGet = 60;
    [SerializeField] private bool isUsed = false;
    [SerializeField] private bool isInside = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isUsed == false && isInside == true)
        {
            var random = Random.Range(0, 100);

            if (random <= 60)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Bottles++;
                isUsed = true;
                Debug.Log("Bottle Found");
            }
            else
            {
                Debug.Log("No Bottle");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.name == "Player")
        {
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D exit)
    {
        if(exit.name == "Player")
        {
            isInside = false;
        }
    }
}
