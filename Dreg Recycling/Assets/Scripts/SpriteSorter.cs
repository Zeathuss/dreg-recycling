using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private int sortingOrder = 5000;
    [SerializeField] private int offset = 0;
    [SerializeField] private bool runOnce = false;
    private Renderer renderer;

    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrder - transform.position.y - offset);
    }
}
