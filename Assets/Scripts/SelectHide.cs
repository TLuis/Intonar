using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHide : MonoBehaviour {

    public GameObject balkenHandler;
    public GameObject selectMovementSphere;
    public GameObject selectRotationSphere;
    public GameObject selectStartSphere;
    public GameObject selectResetSphere;
    public GameObject alignmentBox; 
    bool elementsHidden;
    public bool triggerHide; 
    
    void OnSelect()
    {
        if (elementsHidden == false)
        {
            balkenHandler.GetComponent<BalkenHandler>().Hide();
            selectMovementSphere.SetActive(false);
            selectResetSphere.SetActive(false);
            selectRotationSphere.SetActive(false);
            selectStartSphere.SetActive(false);
            alignmentBox.SetActive(false); 
        }
        //TODO implement a way to make elements visible again
    }

    void Update()
    {
        if(triggerHide == true)
        {
            OnSelect();
            triggerHide = false; 
        }
    }
}
