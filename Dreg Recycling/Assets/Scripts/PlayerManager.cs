using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    public float Money;
    public int Bottles;
    public int glassBottle;

    [SerializeField]public float moveSpeed;

    public float Hunger = 1;
    [SerializeField] private int maxHunger = 0;

    public float Thirst = 1;
    [SerializeField] private int maxThirst = 0;

    public float Health = 1;

    public float defaultSpeed = 5;
    public float moveWhileHungry;
    public float moveWhileThirsty;

    public float hungerSpeed;
    [SerializeField] private float maxHungerSpeed = 1;
    [SerializeField] private float minHungerSpeed = 30;
    public float hungerAmount = 0;
    public float thirstSpeed;
    [SerializeField] private float maxThirstSpeed = 1;
    [SerializeField] private float minThirstSpeed = 20;
    public float thirstAmount = 0;

    public string Difficulty;

    public Vector2 playerPos;

    public float playerYPos;
    public float playerXPos;

    private void Awake()
    {
        Difficulty = PlayerPrefs.GetString("Difficulty");
        playerPos = new Vector2(PlayerPrefs.GetFloat("PlayerXPos"), PlayerPrefs.GetFloat("PlayerYPos"));
    }

    private void Start()
    {
        player.transform.position = playerPos;

        moveWhileHungry = defaultSpeed / 2;
        moveWhileThirsty = defaultSpeed / 2;

        moveSpeed = defaultSpeed;

        hungerSpeed = minHungerSpeed;
        thirstSpeed = minThirstSpeed;

        StartCoroutine(HungerSpeed());
        StartCoroutine(ThirstSpeed());
        StartCoroutine(HungerAmount());
        StartCoroutine(ThirstAmount());










        #region Loading
        Health = PlayerPrefs.GetFloat("Heatlh", 1);
        Thirst = PlayerPrefs.GetFloat("Thirst", 1);
        Hunger = PlayerPrefs.GetFloat("Hunger", 1);
        Money = PlayerPrefs.GetFloat("Money", 0);
        Bottles = PlayerPrefs.GetInt("Bottles", 0);
        glassBottle = PlayerPrefs.GetInt("glassBottle", 0);
        hungerAmount = PlayerPrefs.GetFloat("hungerAmount", 0.05f);
        thirstAmount = PlayerPrefs.GetFloat("thirstAmount", 0.05f);
        thirstSpeed = PlayerPrefs.GetFloat("thirstSpeed", 0);
        hungerSpeed = PlayerPrefs.GetFloat("hungerSpeed", 0);

        moveSpeed = PlayerPrefs.GetFloat("moveSpeed", 5);
        moveWhileHungry = PlayerPrefs.GetFloat("moveWhileHungry", 5);
        moveWhileThirsty = PlayerPrefs.GetFloat("moveWhileThirsty", 5);
        #endregion
    }
    private void Update()
    {
        #region Saving
        PlayerPrefs.SetFloat("Heatlh", Health);
        PlayerPrefs.SetFloat("Thirst", Thirst);
        PlayerPrefs.SetFloat("Hunger", Hunger);
        PlayerPrefs.SetFloat("Money", Money);
        PlayerPrefs.SetInt("Bottles", Bottles);
        PlayerPrefs.SetInt("glassBottle", glassBottle);
        PlayerPrefs.SetFloat("hungerAmount", hungerAmount);
        PlayerPrefs.SetFloat("thirstAmount", thirstAmount);
        PlayerPrefs.SetFloat("thirstSpeed", thirstSpeed);
        PlayerPrefs.SetFloat("hungerSpeed", hungerSpeed);

        PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        PlayerPrefs.SetFloat("moveWhileHungry", moveWhileHungry);
        PlayerPrefs.SetFloat("moveWhileThirsty", moveWhileThirsty);
        #endregion



        playerXPos = player.transform.position.x;
        playerYPos = player.transform.position.y;

        PlayerPrefs.SetFloat("PlayerXPos", playerXPos);
        PlayerPrefs.SetFloat("PlayerYPos", playerYPos);


        if (hungerSpeed >= maxHungerSpeed) hungerSpeed = maxHungerSpeed;
        if (thirstSpeed >= maxThirstSpeed) thirstSpeed = maxThirstSpeed;

        if (hungerSpeed <= minHungerSpeed) hungerSpeed = minHungerSpeed;
        if (thirstSpeed <= minThirstSpeed) thirstSpeed = minThirstSpeed;

        if (Hunger >= maxHunger)
        {
            moveSpeed = moveWhileHungry;
        }
        else moveSpeed = defaultSpeed;

        if (Thirst >= maxThirst)
        {
            moveSpeed = moveWhileThirsty;
        }
        else moveSpeed = defaultSpeed;


        if(FindObjectOfType<ButtonManager>().sellingPanel.activeSelf == true || FindObjectOfType<OpeningShop>().shopPanel.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        if(Hunger < 0)
        {
            Hunger = 0;
        }
        if (Thirst < 0)
        {
            Thirst = 0;
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

        Hunger += hungerAmount;

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

        Thirst += thirstAmount;

        StartCoroutine(ThirstAmount());
    }
}
