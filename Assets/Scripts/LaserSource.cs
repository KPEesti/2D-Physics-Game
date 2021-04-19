using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    public Material material;

    private LaserBeam laserBeam;

    void Start()
    {
        
    }
    
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
        laserBeam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}
