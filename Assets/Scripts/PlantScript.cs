using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class PlantScript : MonoBehaviour
{
    private float timePassed = 0f;
    private bool isTimerGoing = false;
    private Coroutine clickTimer;

    [SerializeField] GameObject player;
    void StartTimer()
    {
        //clear
        isTimerGoing = false;
        if (clickTimer != null)
        {
            StopCoroutine(clickTimer);
        }

        //reset
        timePassed = 0f;
        isTimerGoing = true;


        clickTimer = StartCoroutine(UpdateTimer());
    }


    private IEnumerator UpdateTimer()
    {
        while (isTimerGoing)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= 10f)
            {
                Debug.Log("10 seconds passed!!!!!");

                if (!GameManager.wateredPlant)
                {
                  GameManager.WaterPlant();
                }

                isTimerGoing = false;
                clickTimer = null;
                yield break;
            }

            yield return null;
        }
    }


private void OnMouseDown()
    {
        print("click!");
        //start coroutine for amount of time held!
        StartTimer();

    }

    private void OnMouseUp()
    {
        isTimerGoing = false;

        if (clickTimer != null)
        {
            StopCoroutine(clickTimer);
            clickTimer = null;
        }

        print("stopped holding");
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
