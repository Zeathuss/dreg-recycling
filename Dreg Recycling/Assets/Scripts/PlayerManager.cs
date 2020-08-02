using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float Money;
    public int Bottles;
    public int glassBottle;

    [SerializeField]public float moveSpeed=5f;

    public int Hunger = 0;
    [SerializeField] private int maxHunger = 20;

    public int Thirst = 0;
    [SerializeField] private int maxThirst = 20;


    private void Start()
    {
        StartCoroutine(HungerSpeed());
    }
    private void Update()
    {
        if (Hunger >= maxHunger)
        {
            Hunger = maxHunger;
            moveSpeed = moveSpeed * 0.09f;
        }
        if (Thirst >= maxThirst)
        {
            Thirst = maxThirst;
            moveSpeed = moveSpeed * 0.09f;
        }
    }

    IEnumerator HungerSpeed()
    {
        yield return new WaitForSeconds(6f);

        Hunger++;
        Thirst++;
    }
}
