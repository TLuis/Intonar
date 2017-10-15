using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHide : MonoBehaviour {

    public GameObject balkenHandler;
    
    void OnSelect()
    {
        balkenHandler.GetComponent<BalkenHandler>().Hide();
    }
}
