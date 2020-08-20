using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Job : MonoBehaviour
{
    [SerializeField] private float FinalJobPlayout;
    [SerializeField] private float JobPayout;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            FinalJobPlayout = JobPayout + JobPayout * 0.25f;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Medium")
        {
            FinalJobPlayout = JobPayout;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            FinalJobPlayout = JobPayout - JobPayout * 0.25f;
        }
    }

    void FinishJob()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += FinalJobPlayout;
    }

}
