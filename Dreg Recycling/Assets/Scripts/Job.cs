using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Job : MonoBehaviour
{
    [SerializeField] private float FinalJobPayout;
    [SerializeField] private float JobPlayout;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            FinalJobPayout = JobPlayout + JobPlayout * 0.25f;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Medium")
        {
            FinalJobPayout = JobPlayout;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            FinalJobPayout = JobPlayout - JobPlayout * 0.25f;
        }
    }

    void FinishJob()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += FinalJobPayout;
    }

}
