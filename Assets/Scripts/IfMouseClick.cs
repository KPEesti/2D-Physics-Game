using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfMouseClick : MonoBehaviour
{
    public UnityEvent DoSmth;

    private bool isActive;


    private void OnMouseDown()
    {
        if (!isActive)
        {
            Debug.Log("mouseClick");
            DoSmth?.Invoke();
            isActive = true;
        }
    }
}
