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
    public bool toggleHide;
    
    void OnSelect()
    {
        if (elementsHidden == false)
        {
            balkenHandler.GetComponent<BalkenHandler>().Hide();
            selectMovementSphere.SetActive(false);
            selectResetSphere.SetActive(false);
            selectRotationSphere.SetActive(false);
            selectStartSphere.SetActive(false);
            //alignmentBox.SetActive(false); 
        } else
        {
            selectMovementSphere.SetActive(true);
            selectResetSphere.SetActive(true);
            selectRotationSphere.SetActive(true);
            selectStartSphere.SetActive(true);
            //alignmentBox.SetActive(true);
        }
        elementsHidden = !elementsHidden;
    }

    void Update()
    {
        if(toggleHide == true)
        {
            OnSelect();
            toggleHide = false; 
        }
    }
}
