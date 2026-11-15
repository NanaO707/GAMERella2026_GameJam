using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static bool wateredPlant;
    public static bool fairyGot;
    public static bool fairyUsed;
    public static bool shoutedAtPlant;
    public static bool gameOver;

    //plant
    [SerializeField] private SpriteRenderer plantSprite;
    [SerializeField] private Sprite[] spriteList;

    private static GameManager instance;

    private static int plantStage = 0;

    [SerializeField] public AudioSource audioSource; //used for sound effect of magic or whatever

    [SerializeField] public AudioClip magic1;
    [SerializeField] public AudioClip magic2;
    [SerializeField] public AudioClip magic3;
    [SerializeField] public AudioClip magic4;

    private void Awake()
    {
        instance = this;
        plantStage = 0;
    }
    private void PlantGrow()
    {
        //sfx
        plantStage++;
        plantSprite.sprite = spriteList[plantStage];

    }
    public static void WaterPlant()
    {
        //insatce
        instance.PlantGrow();
        wateredPlant = true;
        //animation sfx whatever
        print("water planted");
    }

    public static void FairyPlant()
    {
        instance.PlantGrow();
        //animation sfx whatever
        print("fairy fed to plant");
    }

    public static void SpeakPlant()
    {
        instance.PlantGrow();
        //animation sfx whatever
        print("final step: enchantment spoken");
    }



}
