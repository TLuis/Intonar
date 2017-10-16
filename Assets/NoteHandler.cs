using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Position(float x, float y, float z)
    {
        this.transform.localPosition = new Vector3(x, y, z);
    }
    public void Scale(float y)
    {
        this.transform.localScale = new Vector3(0.05f, 0.5f * y, 0.05f);
    }
}
