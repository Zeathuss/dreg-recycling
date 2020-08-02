using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessoriesScr : MonoBehaviour
{
    public List<GameObject> Inventory = new List<GameObject>();

    public Image[] InventoryGameObjects;

    public bool Full;
    private int i;
    private float Money;

    [SerializeField] private TMP_Text text;

    private void Update()
    {
        InventoryClick();

        Money = FindObjectOfType<PlayerManager>().Money;
        text.text = "" + System.Math.Round(Money, 2);

        foreach (Image m in InventoryGameObjects)
        {
            if (Inventory.Count >= 1)
            {
                if(Full != true)
                {
                    if (m.sprite == null)
                    {
                        m.sprite = Inventory[i].GetComponent<SpriteRenderer>().sprite;
                        Inventory.Remove(Inventory[i]);
                    }
                }
            }
        }

        #region Checking
        foreach(Image img in InventoryGameObjects)
        {
            if(img.sprite == null)
            {
                Full = false;
            }
            else
            {
                Full = true;
            }
        }
        #endregion
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(Full != true)
            {
                Inventory.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }

    public void InventoryClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
