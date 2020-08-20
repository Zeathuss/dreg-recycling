using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Job : MonoBehaviour
{
    [SerializeField] private float FinalJobPlayout;
    [SerializeField] private float JobPlayout;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            FinalJobPlayout = JobPlayout + JobPlayout * 0.25f;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Medium")
        {
            FinalJobPlayout = JobPlayout;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            FinalJobPlayout = JobPlayout - JobPlayout * 0.25f;
        }
    }

    void FinihJob()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += FinalJobPlayout;
    }

}
