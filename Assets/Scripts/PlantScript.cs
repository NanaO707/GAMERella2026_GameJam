using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class PlantScript : MonoBehaviour
{
    private float timePassed = 0;
    private bool isTimerGoing = false;
    private Coroutine clickTimer;

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

            yield return null;
        }
    }

    private void OnMouseDown()
    {
        print("click!");
        //start coroutine for amount of time held!!!!!!!!1
        StartTimer();
        if (timePassed == 10f)
        {
            print("10 seconds passed!!!!!");

            GameManager.WaterPlant();
            
        }

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
