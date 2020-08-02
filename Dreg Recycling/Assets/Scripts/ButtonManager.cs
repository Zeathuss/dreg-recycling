using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject sellingPanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Button inventoryOpen;
    [SerializeField] private Sprite[] backpackSprites;

    public void closeSelling()
    {
        sellingPanel.SetActive(false);
    }

    public void openInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryOpen.image.sprite = backpackSprites[1];
    }

    public void closedInventory()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen.image.sprite = backpackSprites[0];
    }
}
