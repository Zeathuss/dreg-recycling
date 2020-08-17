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
    public GameObject playButton;
    

    private void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("SetDifficulty"));
    }

    public void setDifficulty(string _difficulty)
    {
        difficulty = _difficulty;
        playButton.SetActive(true);
        difficultyTextObj.SetActive(true);

    }

    private void Update()
    {
        if (difficulty == "Easy")
        {
            difficultyText.text = "jakov je rušan";
        }

        if (difficulty == "Medium")
        {
            difficultyText.text = "jakov je fuj";
        }

        if (difficulty == "Hard")
        {
            difficultyText.text = "fk ju jakov";
        }
    }

}
