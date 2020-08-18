using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    public string difficulty;
    public Text difficultyText;
    public GameObject difficultyTextObj;
    public GameObject playButtonObj;
    public Button playButton;
    

    private void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("SetDifficulty"));
        playButton.interactable = false;
    }

    public void setDifficulty(string _difficulty)
    {
        difficulty = _difficulty;
        playButtonObj.SetActive(true);
        difficultyTextObj.SetActive(true);
        playButton.interactable = true;

    }

    private void Update()
    {
        if (difficulty == "Easy")
        {
            difficultyText.text = "Your family is in town for a long time.For doing jobs ,you will get more money";
        }

        if (difficulty == "Medium")
        {
            difficultyText.text = "You are in town for few years so you will get a bit more money";
        }

        if (difficulty == "Hard")
        {
            difficultyText.text = "You are new in town and you will get least amount of money";
        }
    }

}
