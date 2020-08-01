using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForBottles : MonoBehaviour
{
    public Collider2D trashCollider;
    [SerializeField] private int chanceToGet = 60;
    private void OnTriggerEnter(Collider other)
    {
        if (trashCollider.name == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            var random = Random.Range(0, 100);

            if (random <= 60)
            {
                GetComponent<PlayerManager>().Bottles++;
            }
        }
    }
}
