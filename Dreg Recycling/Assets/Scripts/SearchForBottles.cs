using System.Collections;
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
            var randomBottles = Random.Range(0, 100);
            var randomMoney = Random.Range(0, 100);

            if (randomBottles >=60)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Bottles++;
                isUsed = true;
                Debug.Log("Bottle Found");
            }
            else
            {
                Debug.Log("No Bottle");
            }

            if (randomMoney >= 90)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Money += 0.27f;
                isUsed = true;
                Debug.Log("Money Found");
            }
            else
            {
                Debug.Log("No Money");
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
