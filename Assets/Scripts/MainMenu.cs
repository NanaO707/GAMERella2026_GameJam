using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    //loads level
    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad);
        Debug.Log("Loaded scene works!!!!!");
    }
    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
