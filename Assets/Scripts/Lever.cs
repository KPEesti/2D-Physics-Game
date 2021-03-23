using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isEntered;

    void Update()
    {
        if (isEntered && Input.GetButtonDown("Submit"))
            Debug.Log("nazhal na knopky");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
    }
}
