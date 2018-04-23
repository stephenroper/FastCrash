using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour {

    private string sortingLayerName = "Player";

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = sortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = 0;
    }
}
