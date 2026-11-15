using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using static UnityEngine.Rendering.DebugUI.Table;

public class VoiceActivation : MonoBehaviour{

    //array of plant sprites 
    public Sprite[] plantImages;

    //2D object showing the plant
    public SpriteRenderer plantObject;
    //track of image
    private int currentImage = 0;

    //times player says grow
    private int growCount = 0;

    //tracks voice usage of te interaction
    private bool voiceUsed = false;

    //voice recognition per windows unity documentation
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //starting image
        plantObject.sprite = plantImages[currentImage];

        //action for the word grow
        actions.Add("grow", Grow);

        //voice recognition per windows unity documentation
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += voiceRecognized;
        //takes speech input 
        keywordRecognizer.Start();


    }

     void voiceRecognized(PhraseRecognizedEventArgs speech)
    {
        //checks if voice was used
        if (voiceUsed == true) {
            return;
        }

        //checks for the word grow
        if (speech.text == "grow")
        {
            //increments
            growCount++;
           
            Debug.Log(growCount);

            //changes image based on grow being said 3 times
            if(growCount == 3)
            {
                //one use
                voiceUsed = true;
                //stops listening
                keywordRecognizer.Stop();
                //calls grow
                actions["grow"].Invoke();
            }      

        }   
    }

    private void ChangeImage ()
    {
        //changes image of the plant but doesn't loop
        if (currentImage<plantImages.Length-1)
        {
            currentImage++;
            //changes image on the 2d sprite object
            plantObject.sprite = plantImages[currentImage];

        }
    }
    private void Grow()
    {
        //Calls change image
        ChangeImage();
        Debug.Log("plant grown done");
    }

    private void CleanSpeech()
    {
        //checks that recognizer is there
        if (keywordRecognizer != null)
        {
            //unsubsribes from event
            keywordRecognizer.OnPhraseRecognized -= voiceRecognized;

            //stops it if it's still listening
            if (keywordRecognizer.IsRunning)
            {
                keywordRecognizer.Stop();
            }
            //disposes
            keywordRecognizer.Dispose();
        }
      
    }

    void OnDestroy()
    {
       // calls clean speech
        CleanSpeech();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
