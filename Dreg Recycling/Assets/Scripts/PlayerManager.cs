﻿using System.Collections;
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

    public float hungerSpeed;
    [SerializeField] private float maxHungerSpeed = 1;
    [SerializeField] private float minHungerSpeed = 30;
    public float hungerAmount = 1;
    public float thirstSpeed;
    [SerializeField] private float maxThirstSpeed = 1;
    [SerializeField] private float minThirstSpeed = 20;
    public float thirstAmount = 1;

    private void Start()
    {
        moveWhileHungry = defaultSpeed / 2;
        moveWhileThirsty = defaultSpeed / 2;

        moveSpeed = defaultSpeed;

        hungerSpeed = minHungerSpeed;
        thirstSpeed = minThirstSpeed;

        StartCoroutine(HungerSpeed());
        StartCoroutine(ThirstSpeed());
    }
    private void Update()
    {
        if (hungerSpeed <= maxHungerSpeed) hungerSpeed = maxHungerSpeed;
        if (thirstSpeed <= maxThirstSpeed) thirstSpeed = maxThirstSpeed;

        if (hungerSpeed >= minHungerSpeed) hungerSpeed = minHungerSpeed;
        if (thirstSpeed >= minThirstSpeed) thirstSpeed = minThirstSpeed;

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
        yield return new WaitForSeconds(hungerSpeed);

        hungerAmount -= 0.05f;
        hungerSpeed--;

        StartCoroutine(HungerSpeed());
    }

    IEnumerator HungerAmount()
    {
        yield return new WaitForSeconds(hungerSpeed);

        GameObject.Find("Player").GetComponent<PlayerManager>().Hunger += hungerAmount;

        StartCoroutine(HungerAmount());
    }


    IEnumerator ThirstSpeed()
    {
        yield return new WaitForSeconds(thirstSpeed);

        thirstAmount -= 0.05f;
        thirstSpeed--;

        StartCoroutine(ThirstSpeed());
    }

    IEnumerator ThirstAmount()
    {
        yield return new WaitForSeconds(thirstSpeed);

        GameObject.Find("Player").GetComponent<PlayerManager>().Thirst += thirstAmount;

        StartCoroutine(ThirstAmount());
    }
}
