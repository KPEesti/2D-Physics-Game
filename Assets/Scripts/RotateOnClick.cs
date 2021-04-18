using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateOnClick : MonoBehaviour
{
    [SerializeField] private float angle;
    private void OnMouseDown()
    {
       transform.Rotate(0,0,angle);
    }
}
