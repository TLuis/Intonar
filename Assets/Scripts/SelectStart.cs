using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStart : MonoBehaviour {

    public GameObject balkenHandler;
    public bool triggerStart;

    void OnSelect()
    {
        balkenHandler.GetComponent<BalkenHandler>().Initialize();
    }

    void Update()
    {
        if(triggerStart == true)
        {
            balkenHandler.GetComponent<BalkenHandler>().Initialize();
            triggerStart = false; 
        } 
    }
}
