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

    public float moveWhileHungry;
    public float moveWhileThirsty;


    private void Start()
    {
        moveWhileHungry = defaultSpeed / 2;
        moveWhileThirsty = defaultSpeed / 2;

        moveSpeed = defaultSpeed;
        StartCoroutine(HungerSpeed());
    }
    private void Update()
    {
        if (Hunger >= maxHunger)
        {
            moveSpeed = moveWhileHungry;
        }
        else moveSpeed = moveSpeed;

        if (Thirst >= maxThirst)
        {
            moveSpeed = moveWhileThirsty;
        }
        else moveSpeed = moveSpeed;


        if(FindObjectOfType<ButtonManager>().sellingPanel.activeSelf == true || FindObjectOfType<OpeningShop>().shopPanel.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    IEnumerator HungerSpeed()
    {
        yield return new WaitForSeconds(18f);

        Hunger++;
        Thirst++;

        StartCoroutine(HungerSpeed());
    }
}
