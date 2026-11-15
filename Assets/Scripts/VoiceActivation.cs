using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static UnityEngine.Rendering.DebugUI.Table;

public class VoiceActivation : MonoBehaviour{

    public Sprite[] plantImages;
    public Image displayImage;

    private int currentImage = 0;
    private bool voiceUsed = false;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
   //private new string[] = { "grow", "crescite"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //displayImage.sprite = [currentImage];
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += voiceRecognized;
        //takes speech input 
        keywordRecognizer.Start();


    }

     void voiceRecognized(PhraseRecognizedEventArgs speech)
    {

        actions.Add("grow", Grow);
        actions.Add("crescite", Crescite);
        if (voiceUsed == true) {
            return;
        }


        if (speech.text == "grow" || speech.text == "crescite")
        {

            voiceUsed = true;
            keywordRecognizer.Stop();
            //ChangeImage();
            Debug.Log(speech.text);

        }

        actions[speech.text].Invoke();
    }

    private void ChangeImage ()
    {
        if (currentImage>=plantImages.Length-1)
        {
            currentImage++;
            displayImage.sprite = plantImages[plantImages.Length-1];

        }


       //change plant image
    }
    private void Grow()
    {
        ChangeImage();
    }
    private void Crescite()
    {
        ChangeImage();

    }

    private void CleanSpeech()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //two actions are Grow and Crescite
    //actions.Add("grow", Grow);
    //actions.Add("crescite", Crescite);
}
