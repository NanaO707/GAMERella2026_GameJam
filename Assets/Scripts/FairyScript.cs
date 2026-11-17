using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FairyScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fairywoosh;
    [SerializeField] private AudioClip fairygasp;
    private bool nearby = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        nearby = true;

    }

    private void OnTriggerExit(Collider other)
    {
        nearby = false;
    }

    private void OnMouseDown()
    {
        if (!GameManager.fairyGot)
        {
            GameManager.fairyGot = true;
            print("fairy grabbed");

            //she yells
            GetComponent<AudioSource>().PlayOneShot(fairywoosh);
            GetComponent<AudioSource>().PlayOneShot(fairygasp);
            GetComponent<Light>().intensity = 0;
            //dissapears
            GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
