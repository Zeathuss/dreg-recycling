using UnityEngine;

public class SearchForBottles : MonoBehaviour
{
    [SerializeField] private int chanceToGetBottle = 40;
    [SerializeField] private int chanceToGetGlassBottle = 10;
    [SerializeField] private int chanceToGetMoney = 5;

    [SerializeField] private bool isUsed = false;
    [SerializeField] private bool isInside = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isUsed == false && isInside == true)
        {
            var randomBottles = Random.Range(0, 100);
            var randomMoney = Random.Range(0, 100);
            var randomGlassBottle = Random.Range(0, 100);
            var randomMoneyCount = Random.Range(0.01f,5);

            if (randomBottles >=chanceToGetBottle)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Bottles++;
                isUsed = true;
                Debug.Log("Bottle Found");
            }
            else
            {
                Debug.Log("No Bottle");
            }

            if (randomMoney >= chanceToGetMoney)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().Money += randomMoneyCount;
                isUsed = true;
                Debug.Log("Money Found");
            }
            else
            {
                Debug.Log("No Money");
            }

            if (randomGlassBottle >= chanceToGetGlassBottle)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().glassBottle++;
                isUsed = true;
                Debug.Log("GlassBottle Found");
            }
            else
            {
                Debug.Log("No GlassBottle");
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
}
