using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public GameObject laser;
    public GameObject door;
    public float stopCoordinate;
    public float speed;

    private NewLaserSource laserSource;
    private bool startedMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        laserSource = laser.GetComponent<NewLaserSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedMovement)
            startedMovement = laserSource.lastRaycastedObject.Equals(gameObject);
        else
        {
            if (door.transform.position.y > stopCoordinate)
            {
                var pos = door.transform.position;
                door.transform.position = new Vector3(pos.x, pos.y - speed * Time.deltaTime, pos.z);
            }
        }
    }
}
