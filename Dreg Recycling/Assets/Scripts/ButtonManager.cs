using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject sellingPanel;

    public void closeSelling()
    {
        sellingPanel.SetActive(false);
    }
}
