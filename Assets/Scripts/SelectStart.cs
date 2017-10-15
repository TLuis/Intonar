using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStart : MonoBehaviour {

    public GameObject balkenHandler;

    void OnSelect()
    {
        balkenHandler.GetComponent<BalkenHandler>().Initialize();
    }
}
