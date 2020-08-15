using System.Collections;
using UnityEngine;

public class Food_DrinkMenager : MonoBehaviour
{
    [SerializeField] private bool isDrink; //Piće
    [SerializeField] private bool isFood; //Hrana
    [SerializeField] private bool hasLotSugar; //Hrana ili pića sa puno šećera
    [SerializeField] private bool isSalty; //Hrana ili piće koje je slano aka. tryharder

    [SerializeField] private int Calories; //Kalorije u hrani koje se pri uzimanju djele sa 100 i oduzima se glad
    [SerializeField] private int drinkAmount; //Količina pića u boci koje se pri uzimanju dijeli sa 10 i oduzima se žeđ

    [SerializeField] private int BoostAmount; //Koliko će se ubrzat
    [SerializeField] private int boostLenght; //Koliko će dugo bit ubrzan

    [SerializeField] private int hungerPenalty; //Koliko će bit gladan nakon ubrzanja
    [SerializeField] private int thirstPenalty; //Koliko će bit žedan nakon ubrzanja
    [SerializeField] private int speedPenalty; //Koliko će bit sporiji nakon ubrzanja
    [SerializeField] private int saltPenalty; //Koliko će bit žedan nakon konzumiranja

    [SerializeField] private float hungerSpeed;
    [SerializeField] private float maxHungerSpeed = 1;
    [SerializeField] private float hungerAmount = 0.05f;
    [SerializeField] private float thirstSpeed;
    [SerializeField] private float maxThirstSpeed = 1;
    [SerializeField] private float thirstAmount = 0.05f;

<<<<<<< HEAD

=======
>>>>>>> 74a86b87bc0f0bb56de17f1907d4bac61a12ddf3
    private void Start()
    {
        StartCoroutine(HungerSpeed());
        StartCoroutine(HungerAmount());
        StartCoroutine(ThirstAmount());
        StartCoroutine(ThirstSpeed());
    }

    private void Update()
    {

    }

    void Use()
    {
        if (isDrink)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().thirstSpeed += 2;
            GameObject.Find("Player").GetComponent<PlayerManager>().thirstAmount = 0;

            if (hasLotSugar)
            {
                Drink();
                speedBoost();
            }
            if (isSalty)
            {
                salt();
            }
            else
            {
                Drink();
            }
        }

        if (isFood)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().hungerSpeed += 2;
            GameObject.Find("Player").GetComponent<PlayerManager>().hungerAmount = GameObject.Find("Player").GetComponent<PlayerManager>().Hunger/2;

            if (hasLotSugar)
            {
                Eat();
                speedBoost();
            }
            if (isSalty)
            {
                salt();
            }
            else
            {
                Eat();
            }
        }
    }

    void Eat()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Hunger -= Calories / 100;
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

    void salt()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Thirst += saltPenalty;
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
<<<<<<< HEAD
=======

>>>>>>> 74a86b87bc0f0bb56de17f1907d4bac61a12ddf3
    IEnumerator HungerSpeed()
    {
        yield return new WaitForSeconds(hungerSpeed);

        hungerAmount += 0.05f;
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

        thirstAmount += 0.05f;
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
