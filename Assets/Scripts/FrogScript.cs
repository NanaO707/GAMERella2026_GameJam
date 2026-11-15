using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite singingSprite;
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
        if (GameManager.frogsSinging < 3)
        {
            print("frog interacted: " + GameManager.frogsSinging);
            GameManager.frogsSinging++;
            
            //audioSource.PlayOneShot();

            if (GameManager.frogsSinging == 3)
            {
                GameManager.FrogPlant();
            }

            //changes sprite
            GetComponent<SpriteRenderer>().sprite = singingSprite;

        }
    }
}
