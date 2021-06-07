using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfEnteredTriggerSmth : MonoBehaviour
{
    public UnityEvent DoSmth;

    private bool isActive;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isActive)
        { 
            Debug.Log("enter");
            DoSmth?.Invoke();
            isActive = true;
        }
    }
}
