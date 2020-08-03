using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject sellingPanel;
    public GameObject inventoryPanel;
    public Button inventoryButton;
    public Sprite[] backpackSprites;


    [SerializeField] private string menuSceneName;
    [SerializeField] private string optionsSceneName;
    [SerializeField] private string gameSceneName;

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






    public void startButton()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    
    public void optionsButton()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void backToMenuButton()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
