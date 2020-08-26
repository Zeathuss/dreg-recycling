using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Job : MonoBehaviour
{
    [SerializeField] private float finalJobPayout;
    [SerializeField] private float jobPayout;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            finalJobPayout = jobPayout + jobPayout * 0.25f;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Medium")
        {
            finalJobPayout = jobPayout;
        }
        if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            finalJobPayout = jobPayout * 0.25f;
        }
    }

    void FinishJob()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().Money += finalJobPayout;
    }

}
