using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForBottles : MonoBehaviour
{
    [SerializeField] private int chanceToGet = 60;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var random = Random.Range(0, 100);

            if (random <= 60)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Bottles++;
                Debug.Log("Bottle Found");
            }
            else
            {
                Debug.Log("No Bottle");
            }
        }
    }
}
