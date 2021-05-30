using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfEnteredTriggerSmth : MonoBehaviour
{
    public UnityEvent DoSmth;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("enter");
            DoSmth?.Invoke();
        }
    }
}