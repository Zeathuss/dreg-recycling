using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject sellingPanel;
    public GameObject inventoryPanel;
    public Button inventoryButton;
    public Sprite[] backpackSprites;

    public void closeSelling()
    {
        sellingPanel.SetActive(false);
    }

    public void openInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryButton.image.sprite = backpackSprites[1];
    }
    public void closeInventory()
    {
        inventoryPanel.SetActive(false);
        inventoryButton.image.sprite = backpackSprites[0];
    }
}
