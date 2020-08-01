using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForBottles : MonoBehaviour
{
    public Collider2D trashCollider;
    [SerializeField] private int chanceToGet = 60;
    private void OnTriggerEnter(Collider other)
    {
        if (trashCollider.name == "Trash" && Input.GetKeyDown(KeyCode.Space))
        {
            var random = Random.Range(0, 100);

            if (random <= 60)
            {
<<<<<<< HEAD
                GetComponent<PlayerMenager>().Bottles++;
                Debug.Log("Bottle Found");
            }
            else
            {
                Debug.Log("No Bottle");
=======
                GetComponent<PlayerManager>().Bottles++;
>>>>>>> 52c233317f2828aa5e427310b4979fb0ee4fe8f3
            }
        }
    }
}
