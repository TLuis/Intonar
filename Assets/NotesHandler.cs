using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesHandler : MonoBehaviour {

    public Transform notePrefab;
    Transform note;
    float[] whites = { -40.25f, -37.95f, -35.65f, -33.35f, -31.05f, -28.75f, -26.45f, -24.15f, -21.85f, -19.55f, -17.25f, -14.95f, -12.65f, -10.35f, -8.05f, -5.75f, -3.45f, -1.15f, 1.15f, 3.45f, 5.75f, 8.05f, 10.35f, 12.65f, 14.95f, 17.25f, 19.55f, 21.85f, 24.15f, 26.45f, 28.75f, 31.05f, 33.35f, 35.65f, 37.95f, 40.25f };

    // create notes on notes staff
    void Start () {
        for (int i = 0; i < 36; i++)
        {
            note = Instantiate(notePrefab, Vector3.zero, Quaternion.identity);
            note.SetParent(this.transform);
            note.GetComponent<Note>().Position(whites[i]*.01f, .1f, 0);
        }
    }

	void Update () {
		
	}
}
