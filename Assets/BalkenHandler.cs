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
    float[] wholes1 = {-43.2f,-40.8f,-38.4f,-36f,-33.6f,-31.2f,-28.8f,-26.4f,-24f,-21.6f,-19.2f,-16.8f,-14.4f,-12f,-9.6f,-7.2f,-4.8f,-2.4f,0f,2.4f,4.8f,7.2f,9.6f,12f,14.4f,16.8f,19.2f,21.6f,24f,26.4f,28.8f,31.2f,33.6f,36f};

    List<float> tempoList = new List<float> { 1, 2, 3, 5, 6, 7, 9, 10, 11, 12, 13, 17, 18 };
    List<float> durationList = new List<float> { 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 1, 1 };
    List<int> noteList = new List<int> { 5, 5, 5, 5, 5, 5, 5, 8, 1, 3, 5, 6, 6, 6, 6 };
    List<int> noteList1 = new List<int> { 3, 3, 3, 3, 3, 3, 3, 5, 1, 2, 3, 4, 4, 4, 4};
    List<float> suppList = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    float[,] beat = { { 1f, 1f, 2f, 3f, 4f, 5f, 5f, 6f, 7f, 8f, 9f, 9f, 10f, 11f, 12f, 13f, 13f, 14.5f, 15f, 17f, 17f, 18f, 19f, 20f, 21f, 21f, 22f, 23f, 24f, 25f, 25f, 26f, 27f, 28f, 29f, 29f, 30.5f, 31f, 31f, 31f, 31f, 33f, 33f, 34f, 35f, 36f, 37f, 37f, 38f, 38.5f, 39f, 40f, 41f, 41f, 42f, 42.5f, 43f, 44f, 45f, 46f, 47f, 49f, 49f, 50f, 51f, 52f, 53f, 53f, 54f, 55f, 56f, 57f, 57f, 58f, 59f, 60f, 61f, 61f, 62.5f, 63f, 63f, 63f, 63f }, { 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1.5f, 0.5f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 2f, 1.5f, 0.5f, 2f, 2f, 2f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 0.5f, 0.5f, 1f, 1f, 4f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 1f, 2f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 4f, 1f, 1f, 1f, 1f, 2f, 1.5f, 0.5f, 2f, 2f, 2f, 2f }, { -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -6f, 1f, 1f, 2f, 3f, -2f, 3f, 2f, 2f, -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -2f, 1f, 1f, 2f, 3f, -2f, 2f, 1f, -2f, -4f, -6f, 1f, -2f, 2f, 2f, 3f, 1f, -2f, 2f, 3f, 4f, 3f, 1f, -2f, 2f, 3f, 4f, 3f, 2f, 1f, 2f, -2f, -6f, 3f, 3f, 4f, 5f, -2f, 5f, 4f, 3f, 2f, -6f, 1f, 1f, 2f, 3f, -2f, 2f, 1f, 1f, -2f, -4f, -6f }
    , { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };

    int bpm2sec = 1/60;

    float whole = 1;
    float half = 0.5f;
    float quarter = 0.25f;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Time.fixedTime > beat[0,i] && i < beat.Length)
        {
            balken = Instantiate(balkenPrefab, Vector3.zero, Quaternion.identity);
            balken.SetParent(this.transform);
            balken.GetComponent<Balken>().Position(wholes1[(int)beat[2,i]+16]*0.01f - 0.072f, y_top, 0); 
            balken.GetComponent<Balken>().SetLength(0);
            i++;
        }


        if (this.transform.childCount != 0 && Time.fixedTime < 64)
        {
            int j = 0;
            foreach (Transform balken in transform)
            {

                if (balken.transform.localScale.y < beat[1,j] * y_scale && beat[3,j] == 0)
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
                    beat[3,j] = 1;
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
