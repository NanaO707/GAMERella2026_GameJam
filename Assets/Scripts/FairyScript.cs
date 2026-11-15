using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FairyScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!GameManager.fairyGot)
        {
            GameManager.fairyGot = true;
            print("fairy grabbed");

            //she yells
            //audioSource.PlayOneShot();

            //dissapears
            GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
