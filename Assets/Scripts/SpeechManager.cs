using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject hologram; 
    public bool triggerMove;
    public GameObject debugTextObject; 

    HologramPlacement hologramPlacementScript; 

    /*
    // Use this for initialization
    void Start()
    {
        hologramPlacementScript = hologram.GetComponent<HologramPlacement>();
        keywords.Add("Fix", () =>
        {
            this.BroadcastMessage("OnFix", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Move", () =>
        {
            debugTextObject.GetComponent<TextMesh>().text = debugTextObject.GetComponent<TextMesh>().text + 
                "Speech move recognized and handler called.\n";
            //hologramPlacementScript.OnMoving(HologramPlacement.Axis.ALL);
            //this.BroadcastMessage("OnMoving", HologramPlacement.Axis.ALL, SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Move x", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.X, SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Move y", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Y, SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Move z", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Z, SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Rotate", () =>
        {
            this.BroadcastMessage("OnRotating", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Play", () =>
        {
            this.BroadcastMessage("OnPlay", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("Reset", () =>
        {
            this.BroadcastMessage("OnReset", SendMessageOptions.DontRequireReceiver);
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        debugTextObject.GetComponent<TextMesh>().text = debugTextObject.GetComponent<TextMesh>().text +
            "Some voice command was recognized.\n";
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    private void Update()
    {
        if(triggerMove == true)
        {
            hologramPlacementScript.OnMoving(HologramPlacement.Axis.ALL);
            triggerMove = false;
        }
    }
    */
}