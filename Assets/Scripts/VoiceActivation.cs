using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static UnityEngine.Rendering.DebugUI.Table;

public class VoiceActivation : MonoBehaviour{

    [SerializeField] GameObject plantImage;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string,System.Action>();

    //string[] spokenWords = {"grow", "crescite"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //two actions are Grow and Crescite
        actions.Add("grow", Grow);
        actions.Add("crescite", Crescite);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += voiceRecognized;
        //takes speech input 
        keywordRecognizer.Start();




    }

    private void voiceRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Grow()
    {
       //change plant image
    }

    private void Crescite()
    {
        //change plant image
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
