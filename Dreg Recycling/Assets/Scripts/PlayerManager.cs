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

    public float Hunger = 0;
    [SerializeField] private int maxHunger = 1;

    public float Thirst = 0;
    [SerializeField] private int maxThirst = 1;

    public float Health = 1;

    public float defaultSpeed = 5;

    public float moveWhileHungry;
    public float moveWhileThirsty;


    private void Start()
    {
        moveWhileHungry = defaultSpeed / 2;
        moveWhileThirsty = defaultSpeed / 2;

        moveSpeed = defaultSpeed;
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
}
