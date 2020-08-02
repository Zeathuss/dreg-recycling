using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public float Money;
    public int Bottles;
    public int glassBottle;

    [SerializeField]public float moveSpeed;

    public int Hunger = 0;
    [SerializeField] private int maxHunger = 20;

    public int Thirst = 0;
    [SerializeField] private int maxThirst = 20;

    public float defaultSpeed = 5;
    public float speedWhileHungry = 0.5f;


    private void Start()
    {
        moveSpeed = defaultSpeed;
        StartCoroutine(HungerSpeed());
    }
    private void Update()
    {
        if (Hunger >= maxHunger)
        {
            Hunger = maxHunger;
            moveSpeed = speedWhileHungry;
        }
        else
        {
            moveSpeed = defaultSpeed;
        }
        if (Thirst >= maxThirst)
        {
            Thirst = maxThirst;
            moveSpeed = speedWhileHungry;
        }
        else
        {
            moveSpeed = defaultSpeed;
        }
    }

    IEnumerator HungerSpeed()
    {
        yield return new WaitForSeconds(6f);

        Hunger++;
        Thirst++;
    }
}
