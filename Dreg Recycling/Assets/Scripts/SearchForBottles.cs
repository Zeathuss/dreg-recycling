using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class SearchForBottles : MonoBehaviour
{
    [SerializeField] private int chanceToGetBottle = 40;
    [SerializeField] private int chanceToGetGlassBottle = 10;
    [SerializeField] private int chanceToGetMoney = 5;

    [SerializeField] private bool isUsed = false;
    [SerializeField] private bool isInside = false;

    [SerializeField] private float timeToSearch;
    [SerializeField] private float timePressingSpace;

    [SerializeField] private GameObject glassBottle;
    [SerializeField] private GameObject plasticBottle;
    [SerializeField] private GameObject moneyGet;

    private Transform progressBar;
    private Transform Bar;
    private bool progressBarExists = true;

    [SerializeField] private Sprite openedTrashcan;

    private void Awake()
    {
        if (progressBarExists)
        {
            progressBar = gameObject.transform.GetChild(0);
            Bar = progressBar.transform.GetChild(0);
        }
    }

    private void Update()
    {
        if (!FindObjectOfType<AccessoriesScr>().Full)
        {
            if (progressBarExists)
            {
                if (!isInside)
                {
                    progressBar.gameObject.SetActive(false);
                }
                else
                {
                    progressBar.gameObject.SetActive(true);
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    timePressingSpace += Time.deltaTime;
                    SetSize(timePressingSpace * 2);

                    if (timePressingSpace >= timeToSearch && isUsed == false && isInside == true)
                    {
                        var randomBottles = Random.Range(0, 100);
                        var randomMoney = Random.Range(0, 100);
                        var randomGlassBottle = Random.Range(0, 100);
                        var randomMoneyCount = Random.Range(0.01f, 5);

                        gameObject.GetComponent<SpriteRenderer>().sprite = openedTrashcan;

                        if (randomBottles <= chanceToGetBottle)
                        {
                            GameObject.Find("Player").GetComponent<PlayerManager>().Bottles++;
                            isUsed = true;
                            Debug.Log("Bottle Found");
                        }
                        else
                        {
                            isUsed = true;
                            Debug.Log("No Bottle");
                        }

                        if (randomMoney <= chanceToGetMoney)
                        {
                            GameObject.Find("Player").GetComponent<PlayerManager>().Money += randomMoneyCount;
                            isUsed = true;
                            Debug.Log("Money Found");
                        }
                        else
                        {
                            isUsed = true;
                            Debug.Log("No Money");
                        }

                        if (randomGlassBottle <= chanceToGetGlassBottle)
                        {
                            GameObject.Find("Player").GetComponent<PlayerManager>().glassBottle++;
                            isUsed = true;
                            Debug.Log("GlassBottle Found");


                        }
                        else
                        {
                            isUsed = true;
                            Debug.Log("No GlassBottle");
                        }
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) || !isInside)
                {
                    timePressingSpace = 0;
                    SetSize(0);
                }

                if (Bar.localScale.x > 4)
                {
                    progressBarExists = false;
                    SetSize(4);
                    Destroy(progressBar.gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.name == "Player")
        {
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.name == "Player")
        {
            isInside = false;
        }
    }

    public void SetSize(float sizeNormalized)
    {
        if(progressBarExists)
        {
            Bar.localScale = new Vector3(sizeNormalized, 1f);
        }
    }
}
