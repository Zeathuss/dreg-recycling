using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public string difficulty;
    public Text difficultyText;
    public GameObject difficultyTextObj;
    public GameObject playButtonObj;
    public Button playButton;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);

        playButton.interactable = false;
    }


    public void setDifficulty(string _difficulty)
    {
        difficulty = _difficulty;
        playButtonObj.SetActive(true);
        difficultyTextObj.SetActive(true);
        playButton.interactable = true;
        PlayerPrefs.SetString("Difficulty", difficulty);
    }

    public void difficultyWasSet()
    {
        difficultyTextObj.SetActive(true);
        playButtonObj.SetActive(true);
    }

    private void Update()
    {

        if (difficulty == "Easy")
        {
            difficultyText.text = "Your family has been in town for a long time. If you finish a job, you will get more money.";
        }

        if (difficulty == "Medium")
        {
            difficultyText.text = "You have been in town for a few years, you will get a standard amount of money.";
        }

        if (difficulty == "Hard")
        {
            difficultyText.text = "You are new in town and you will get the least amount of money.";
        }
    }

}
