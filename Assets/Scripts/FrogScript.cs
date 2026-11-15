using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private AudioClip croak;
    [SerializeField] private Sprite singingSprite;

    private bool clicked;
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
        if (GameManager.frogsSinging < 3 && clicked==false)
        {
            print("frog interacted: " + GameManager.frogsSinging);
            GameManager.frogsSinging++;
            GetComponent<Animation>().Play();
            //audioSource.PlayOneShot();
            clicked = true;
            if (GameManager.frogsSinging == 3)
            {
                GameManager.FrogPlant();
                GetComponent<AudioSource>().Play();
            }

            //changes sprite
            GetComponent<SpriteRenderer>().sprite = singingSprite;

        }
    }
}
