using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotationScript : MonoBehaviour {

    public GameObject referenceFrame;

    void OnSelect()
    {
        referenceFrame.GetComponent<HologramPlacement>().OnRotating();
    }
}
