using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BalkenHandler : MonoBehaviour {

    Transform balken;
    public Transform balkenPrefab;
    Transform black;
    public Transform blackPrefab;

    static float blackOffset = 0.01f;
    static float bpm = 120; // bpm
    static float convbpm = 0.01666667f;
    static float meterspersecond = 0.05f*convbpm*bpm; //5cm/s
    static float speed = 0; //later.. speed = meterspersecond*Time.deltaTime
    //begin and end
    float y_bottom = 0;
    float y_top = .1f;
    int i = 0;
    static float luecke = 0.01f;
    float y_scale = (.05f-luecke)*convbpm*bpm;
    float startTime = 0;
    float deltaTime = 0;
    public bool temp_start = false;
    public bool temp_reset = false;
    public float balkenPos = 0.07f;

    bool started = false;
    bool reseted = false;
    public bool hidden = false;
    bool condHid = false;

    float[] keys = { -40.25f, -39.4f, -37.95f, -36.5f, -35.65f, -33.35f, -32.5f, -31.05f, -29.9f, -28.75f, -27.3f, -26.45f, -24.15f, -23.3f, -21.85f, -20.4f, -19.55f, -17.25f, -16.4f, -14.95f, -13.8f, -12.65f, -11.2f, -10.35f, -8.05f, -7.2f, -5.75f, -4.3f, -3.45f, -1.15f, -0.3f, 1.15f, 2.3f, 3.45f, 4.9f, 5.75f, 8.05f, 8.9f, 10.35f, 11.8f, 12.65f, 14.95f, 15.8f, 17.25f, 18.4f, 19.55f, 21f, 21.85f, 24.15f, 25f, 26.45f, 27.9f, 28.75f, 31.05f, 31.9f, 33.35f, 34.5f, 35.65f, 37.1f, 37.95f, 40.25f };

    //position of keys
    float[] whites = { -40.25f, -37.95f, -35.65f, -33.35f, -31.05f, -28.75f, -26.45f, -24.15f, -21.85f, -19.55f, -17.25f, -14.95f, -12.65f, -10.35f, -8.05f, -5.75f, -3.45f, -1.15f, 1.15f, 3.45f, 5.75f, 8.05f, 10.35f, 12.65f, 14.95f, 17.25f, 19.55f, 21.85f, 24.15f, 26.45f, 28.75f, 31.05f, 33.35f, 35.65f, 37.95f, 40.25f };
    float[] blacks = { -39.4f, -36.5f, -32.5f, -29.9f, -27.3f, -23.3f, -20.4f, -16.4f, -13.8f, -11.2f, -7.2f, -4.3f, -0.3f, 2.3f, 4.9f, 8.9f, 11.8f, 15.8f, 18.4f, 21f, 25f, 27.9f, 31.9f, 34.5f, 37.1f };

    //notes
    List<float> tempoList = new List<float> { 1f, 1f, 2f, 3f, 4f, 5f, 5f, 6f, 7f, 8f, 9f, 9f, 10f, 11f, 12f, 13f, 13f, 14.5f, 15f, 17f, 17f, 18f, 19f, 20f, 21f, 21f, 22f, 23f, 24f, 25f, 25f, 26f, 27f, 28f, 29f, 29f, 30.5f, 31f, 31f, 31f, 31f, 33f, 33f, 34f, 35f, 36f, 37f, 37f, 38f, 38.5f, 39f, 40f, 41f, 41f, 42f, 42.5f, 43f, 44f, 45f, 46f, 47f, 49f, 49f, 50f, 51f, 52f, 53f, 53f, 54f, 55f, 56f, 57f, 57f, 58f, 59f, 60f, 61f, 61f, 62.5f, 63f, 63f, 63f, 63f };
    List<float> durationList = new List<float> { 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1.5f, 0.5f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 2f, 1.5f, 0.5f, 2f, 2f, 2f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 0.5f, 0.5f, 1f, 1f, 4f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 1f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 2f, 1.5f, 0.5f, 2f, 2f, 2f, 2f };
    List<float> noteList = new List<float> { -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -6f, 1f, 1f, 2f, 3f, -2f, 3f, 2f, 2f, -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -2f, 1f, 1f, 2f, 3f, -2f, 2f, 1f, -2f, -4f, -6f, 1f, -2f, 2f, 2f, 3f, 1f, -2f, 2f, 3f, 4f, 3f, 1f, -2f, 2f, 3f, 4f, 3f, 2f, 1f, 2f, -2f, -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -6f, 1f, 1f, 2f, 3f, -2f, 2f, 1f, 1f, -2f, -4f, -6f };
    List<float> suppList = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    List<int> whiteblack = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    // Use this for initialization
    void Start()
    {  

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!hidden && !condHid)
        {
            for (int i = 0; i < whites.Length; i++)
            {
                balken = Instantiate(balkenPrefab, Vector3.zero, Quaternion.identity);
                balken.SetParent(this.transform);
                balken.GetComponent<Balken>().Position(whites[i] * 0.01f, y_top - 0.1f, balkenPos);
                balken.GetComponent<Balken>().SetLength(0.5f);
            }

            for (int i = 0; i < blacks.Length; i++)
            {
                balken = Instantiate(blackPrefab, Vector3.zero, Quaternion.identity);
                balken.SetParent(this.transform);
                balken.GetComponent<Balken>().Position(blacks[i] * 0.01f, y_top - 0.1f, balkenPos - blackOffset);
                balken.GetComponent<Balken>().SetLength(0.5f);
            }
            condHid = true;
            started = false;
        }
        if (hidden && condHid)
        {
            foreach (Transform balken in transform)
            {
                Destroy(balken.gameObject);
            }
            condHid = false;
        }
        if(started && hidden) {
            deltaTime = Time.fixedTime - startTime;
            if ( i < tempoList.Count )
            if ( deltaTime > tempoList[i])
            {
                if (whiteblack[i] == 0)
                {
                    balken = Instantiate(balkenPrefab, Vector3.zero, Quaternion.identity);
                    balken.SetParent(this.transform);
                    balken.transform.localRotation = Quaternion.identity;
                    balken.GetComponent<Balken>().Position(whites[(int)noteList[i] + 14] * 0.01f, y_top, balkenPos);
                    balken.GetComponent<Balken>().SetLength(0);
                }
                if (whiteblack[i] == 1)
                {
                    balken = Instantiate(blackPrefab, Vector3.zero, Quaternion.identity);
                    balken.SetParent(this.transform);
                    balken.transform.localRotation = Quaternion.identity;
                    balken.GetComponent<Balken>().Position(blacks[(int)noteList[i] + 12] * 0.01f, y_top, balkenPos - blackOffset);
                    balken.GetComponent<Balken>().SetLength(0);
                }
                i++;
            }

            if(i == tempoList.Count)
            {
                Reset();
            }

            speed = meterspersecond * Time.deltaTime;

            if (this.transform.childCount != 0)
            {
            int j = 0;
            if(balken.gameObject.activeSelf)
            foreach (Transform balken in transform)
            {
                //increase size when new until size is reached
                if (balken.transform.localScale.y < durationList[j] * y_scale && suppList[j] == 0)
                {
                    balken.GetComponent<Balken>().SetLength(balken.transform.localScale.y + speed);
                }
                //decrease size when bottom is reached
                else if (balken.GetComponent<Balken>().GetY_bottom() < y_bottom)
                {
                    balken.GetComponent<Balken>().SetY_top(balken.GetComponent<Balken>().GetY_top() - speed);
                    balken.GetComponent<Balken>().SetLength(balken.transform.localScale.y - speed);
                }
                //move down
                else
                {
                    balken.GetComponent<Balken>().Move(0, -speed, 0);
                    suppList[j] = 1;
                }
                //inactivate
                if (balken.transform.localPosition.y < y_bottom)
                {
                    balken.gameObject.SetActive(false);
                }
                j++;
                }
            }
        }
        //reset state
        if(reseted)
        {
            foreach (Transform balken in transform)
            {
                Destroy(balken.gameObject);
            }
            for (int s = 0; s < suppList.Count; s++)
            {
                suppList[s] = 0;   
            }
            i = 0;
            Initialize();
        }

        //start and reset temps
        if(temp_start)
        {
            Initialize();
            temp_start = false;
        }

        if (temp_reset)
        {
            Reset();
            temp_reset = false;
        }
    }

    public void Initialize()
    {
        reseted = false;
        started = true;
        startTime = Time.fixedTime;
    }

    public void Reset()
    {
        reseted = true;
        started = false;
    }
     
    public void Hide()
    {
        hidden = !hidden;
    }
}
