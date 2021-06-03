using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalButton : MonoBehaviour
{
    public GameObject crystal;
    public float degreesPerClick = 0.1f;

    private Transform crystalTransform;

    // Start is called before the first frame update
    void Start()
    {
        crystalTransform = crystal.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        crystalTransform.Rotate(0, 0, degreesPerClick * Time.deltaTime);
        Debug.Log("Crystal button is pressed");
    }
}
