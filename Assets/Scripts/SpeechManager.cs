using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Fix", () =>
        {
            this.BroadcastMessage("OnFix");
        });

        keywords.Add("Move", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.ALL);
        });

        keywords.Add("Move x", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.X);
        });

        keywords.Add("Move y", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Y);
        });

        keywords.Add("Move z", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Z);
        });

        keywords.Add("Rotate", () =>
        {
            this.BroadcastMessage("OnRotating");
        });

        keywords.Add("Play", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Z);
        });

        keywords.Add("Reset", () =>
        {
            this.BroadcastMessage("OnMoving", HologramPlacement.Axis.Z);
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}