using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectReset : MonoBehaviour {

    public GameObject balkenHandler;

    void OnSelect()
    {
        balkenHandler.GetComponent<BalkenHandler>().Reset();
    }
}
