using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balken : MonoBehaviour {

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
        this.transform.localScale = new Vector3(0.05f, 0.5f*y, 0.05f);
    }

    public void Move(float x, float y, float z)
    {
        this.transform.localPosition += new Vector3(x, y, z);
    }

    public float GetY_top()
    {
        return this.transform.localPosition.y + this.transform.localScale.y / 2;
    }

    public float GetY_bottom()
    {
        return this.transform.localPosition.y - this.transform.localScale.y / 2;
    }

    public void SetY_top(float y)
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, y - this.transform.localScale.y/2, this.transform.localPosition.z);
    }

    public void SetLength(float length)
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, GetY_top() - length / 2, this.transform.localPosition.z);
        this.transform.localScale = new Vector3(this.transform.localScale.x, length, this.transform.localScale.z);
    }
}
