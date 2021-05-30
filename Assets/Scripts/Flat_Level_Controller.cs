using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flat_Level_Controller : MonoBehaviour
{
    private int _appleCount;

    public Collider2D ExitCollider;
    
    void Update()
    {
        if (_appleCount >= 3)
            ExitCollider.enabled = false;
    }

    public void UpdateAppleCount()
    {
        _appleCount++;
        Debug.Log(_appleCount);
    }
}
