using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_DrinkMenager : MonoBehaviour
{
    [SerializeField] private bool isDrink; //Piće
    [SerializeField] private bool isFood; //Hrana
    [SerializeField] private bool hasLotSugar; //Hrana ili pića sa puno šećera

    [SerializeField] private int Calories; //Kalorije u hrani koje se pri uzimanju djele sa 100 i oduzima se glad
    [SerializeField] private int drinkAmount; //Količina pića u boci koje se pri uzimanju dijeli sa 10 i oduzima se žeđ

    [SerializeField] private int BoostAmount; //Koliko će se ubrzat
    [SerializeField] private int boostLenght; //Koliko će dugo bit ubrzan

    [SerializeField] private int hungerPenalty; //Koliko će bit gladan nakon ubrzanja
    [SerializeField] private int thirstPenalty; //Koliko će bit žedan nakon ubrzanja
    [SerializeField] private int speedPenalty; //Koliko će bit sporiji nakon ubrzanja

    void Use()
    {
        if (isDrink)
        {
            Drink();
        }
        if (isDrink && hasLotSugar)
        {
            Drink();
            speedBoost();
        }

        if (isFood)
        {
            Eat();
        }
        if (isFood && hasLotSugar)
        {
            Eat();
            speedBoost();
        }
    }

    void Eat()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Hunger-=Calories/100;
        Destroy(this);
    }

    void Drink()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Hunger -= drinkAmount / 10;
        Destroy(this);
    }

    void speedBoost()
    {
        StartCoroutine(SpeedBoostPenalty());
    }

    IEnumerator SpeedBoostPenalty()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().moveSpeed += BoostAmount;

        yield return new WaitForSeconds(boostLenght);

        GameObject.Find("Player").GetComponent<PlayerManager>().Hunger += hungerPenalty;
        GameObject.Find("Player").GetComponent<PlayerManager>().Thirst += thirstPenalty;
        GameObject.Find("Player").GetComponent<PlayerManager>().moveSpeed -= speedPenalty;

        StopCoroutine(SpeedBoostPenalty());

        Destroy(this);
    }
}
