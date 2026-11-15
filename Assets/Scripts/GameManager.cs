using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static bool wateredPlant;
    public static bool fairyGot;
    public static bool shoutedAtPlant;
    public static bool gameOver;

    //plant
    [SerializeField] static Sprite plantSprite;
    [SerializeField] public static Sprite[] spriteList;
    private static int plantStage = 0;

    [SerializeField] public AudioSource audioSource; //used for sound effect of magic or whatever

    [SerializeField] public AudioClip magic1;
    [SerializeField] public AudioClip magic2;
    [SerializeField] public AudioClip magic3;
    [SerializeField] public AudioClip magic4;

    static void PlantGrow()
    {
        //sfx
        plantSprite = spriteList[++plantStage];

    }
    public static void WaterPlant()
    {
        PlantGrow();
        //animation sfx whatever
        print("water planted");
    }

    public static void FairyPlant()
    {
        PlantGrow();
        //animation sfx whatever
        print("fairy fed to plant");
    }

    public static void SpeakPlant()
    {
        PlantGrow();
        //animation sfx whatever
        print("final step: enchantment spoken");
    }



}
