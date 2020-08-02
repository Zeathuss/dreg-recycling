using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStuff : MonoBehaviour
{
    [SerializeField] private GameObject[] FoodNDrinks;

    public void buyItem(string name)
    {
        var Money = FindObjectOfType<PlayerManager>().Money;
        if(FindObjectOfType<AccessoriesScr>().Full != true)
        {
            if (name == "Bacon" && Money >= 4.50f)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[0]);
                FindObjectOfType<PlayerManager>().Money -= 4.50f;
            }
            else if (name == "BurgerHam" && Money >= 5.50f)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[1]);
                FindObjectOfType<PlayerManager>().Money -= 5.50f;
            }
            else if (name == "ReoReo" && Money >= 9)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[2]);
                FindObjectOfType<PlayerManager>().Money -= 9;
            }
            else if (name == "Sausage" && Money >= 10)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[3]);
                FindObjectOfType<PlayerManager>().Money -= 10;
            }
            else if (name == "Swedish Meatballs" && Money >= 12.50f)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[4]);
                FindObjectOfType<PlayerManager>().Money -= 12.50f;
            }
            else if (name == "Snekers" && Money >= 3.20)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[5]);
                FindObjectOfType<PlayerManager>().Money -= 3.20f;
            }
            else if (name == "Zippa" && Money >= 15)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[6]);
                FindObjectOfType<PlayerManager>().Money -= 15;
            }
            else if (name == "Doughnut" && Money >= 2)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[7]);
                FindObjectOfType<PlayerManager>().Money -= 2;
            }
            else if (name == "Blue Cow Energy" && Money >= 5.50f)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[8]);
                FindObjectOfType<PlayerManager>().Money -= 5.50f;
            }
            else if (name == "Juice" && Money >= 11.50f)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[9]);
                FindObjectOfType<PlayerManager>().Money -= 11.50f;
            }
            else if (name == "Teddy Energy" && Money >= 7)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[10]);
                FindObjectOfType<PlayerManager>().Money -= 7;
            }
            else if (name == "Water" && Money >= 2)
            {
                FindObjectOfType<AccessoriesScr>().Inventory.Add(FoodNDrinks[11]);
                FindObjectOfType<PlayerManager>().Money -= 2;
            }
        }
    }
}
