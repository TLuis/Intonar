using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalkenHandler : MonoBehaviour {

    Transform balken;
    public Transform balkenPrefab;
    float speed = 0.005f;
    float y_bottom = 0;
    float y_top = .01f;
    int i = 0;
    float y_scale = .1f;

    float[] keys = { -14.3f, -13f, -11.7f, -10.4f, -9.1f, -7.8f, -6.5f, -5.2f, -3.9f, -2.6f, -1.3f, 0, 1.3f, 2.6f, 3.9f, 5.2f, 6.5f, 7.8f, 9.1f, 10.4f, 11.7f, 13.0f, 14.3f };
    //float[] keys = { -1.43f, -1.3f, -1.17f, -1.04f, -0.91f, -0.78f, -0.65f, -0.52f, -0.39f, -0.26f, -0.13f, 0, 0.13f, 0.26f, 0.39f, 0.52f, 0.65f, 0.78f, 0.91f, 1.04f, 1.17f, 1.30f, 1.43f };
    float[] rest = { 1, 0.5f, 0.25f, 0.125f };
    float[] wholes = { -8.4f, -6f, -3.6f, -1.2f, 1.2f, 3.6f, 6f, 8.4f };

    List<float> tempoList = new List<float> { 1, 2, 3, 5, 6, 7, 9, 10, 11, 12, 13, 17, 18 };
    List<float> durationList = new List<float> { 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 1, 1 };
    List<int> noteList = new List<int> { 5, 5, 5, 5, 5, 5, 5, 8, 1, 3, 5, 6, 6, 6, 6 };
    List<int> noteList1 = new List<int> { 3, 3, 3, 3, 3, 3, 3, 5, 1, 2, 3, 4, 4, 4, 4};
    List<float> suppList = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    int bpm2sec = 1/60;

    float whole = 1;
    float half = 0.5f;
    float quarter = 0.25f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Time.fixedTime > tempoList[i] && i < 15)
        {
            balken = Instantiate(balkenPrefab, Vector3.zero, Quaternion.identity);
            balken.SetParent(this.transform);
            balken.GetComponent<Balken>().Position(wholes[noteList1[i]]*0.01f - 0.072f, y_top, 0); 
            balken.GetComponent<Balken>().SetLength(0);
            i++;
        }


        if (this.transform.childCount != 0)
        {
            int j = 0;
            foreach (Transform balken in transform)
            {

                if (balken.transform.localScale.y < durationList[j] * y_scale && suppList[j] == 0)
                {
                    balken.GetComponent<Balken>().SetLength(balken.transform.localScale.y + speed);
                }

                else if (balken.GetComponent<Balken>().GetY_bottom() < y_bottom)
                {
                    balken.GetComponent<Balken>().SetY_top(balken.GetComponent<Balken>().GetY_top() - speed);
                    balken.GetComponent<Balken>().SetLength(balken.transform.localScale.y - speed);
                }

                else
                {
                    balken.GetComponent<Balken>().Move(0, -speed, 0);
                    suppList[j] = 1;
                }

                if (balken.transform.localPosition.y < y_bottom)
                {
                    balken.gameObject.active = false;
                    //suppList.RemoveAt(j);
                    //durationList.RemoveAt(j);
                    //noteList.RemoveAt(j);
                    //tempoList.RemoveAt(j);
                    //j--;
                }

                j++;
            }
        }
    }

    void Update()
    {
       
    }
}
