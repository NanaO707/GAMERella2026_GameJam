using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class InteractableObject : MonoBehaviour

  
{
    
    private void OnMouseDown()
    {
        print("click!");

    }

    private void OnMouseOver()
    {
        print("hovering over");
    }

    private void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
