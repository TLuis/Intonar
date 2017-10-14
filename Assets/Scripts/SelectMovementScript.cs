using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMovementScript : MonoBehaviour {

    public GameObject referenceFrame;

    void OnSelect()
    {
        referenceFrame.GetComponent<HologramPlacement>().OnMoving(HologramPlacement.Axis.ALL);
    }
}
