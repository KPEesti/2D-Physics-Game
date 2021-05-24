using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessRemover : MonoBehaviour
{
    public GameObject laser;
    public GameObject darknessObject;

    private NewLaserSource laserSource;

    // Start is called before the first frame update
    void Start()
    {
        laserSource = laser.GetComponent<NewLaserSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laserSource.lastRaycastedObject.Equals(gameObject))
        {
            darknessObject.SetActive(false);
            this.enabled = false;
        }
    }
}
