using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour 
{
    public static bool wateredPlant;
    public static bool fairyGot;
    public static bool fairyUsed;
    public static bool shoutedAtPlant;
    public static int frogsSinging;
    public static bool gameOver;

    //plant
    [SerializeField] private SpriteRenderer plantSprite;
    [SerializeField] private Sprite[] spriteList;
    [SerializeField] private Light light;

    private static GameManager instance;

    private static int plantStage = 0;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip magicWater;
    [SerializeField] private AudioClip magicFairy;
    [SerializeField] private AudioClip magicVoice;
    [SerializeField] private AudioClip magicFrogs;
    [SerializeField] private AudioClip gameOverMusic;

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
        light.intensity += 10;
        if (plantStage == 4)
        {
            gameOver = true;
        }

    }
    public static void WaterPlant()
    {
        //insatce
        instance.PlantGrow();
        wateredPlant = true;
        //animation sfx whatever
        instance.audioSource.PlayOneShot(instance.magicWater);
        print("water planted");
    }

    public static void FairyPlant()
    {
        instance.PlantGrow();
        //animation sfx whatever
        instance.audioSource.PlayOneShot(instance.magicFairy);

        print("fairy fed to plant");
    }

    public static void SpeakPlant()
    {
        instance.PlantGrow();
        //animation sfx whatever
        instance.audioSource.PlayOneShot(instance.magicVoice);

        print("final step: enchantment spoken");
    }

    public static void FrogPlant()
    {
        instance.PlantGrow();
        //animation sfx whatever
        instance.audioSource.PlayOneShot(instance.magicFrogs);

        print("frogs have sung");
    }
    public string levelToLoad;

    public void GameOver()
    {
        instance.audioSource.PlayOneShot(instance.gameOverMusic);
        Wait();
        SceneManager.LoadScene(levelToLoad);

    }

    public static async void Wait()
    {
        await Task.Delay(5000); // Wait 2000 milliseconds (2 seconds)
    
    }
}
