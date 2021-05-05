using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaserSource : MonoBehaviour
{
    public int numberReflectionMax = 5;

    private LineRenderer lineRenderer;
    private int laserDistance = 100;
    private Vector3 pos = new Vector3();
    private Vector3 directLaser = new Vector3();
    bool loopActive = true;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLaser();
    }

    private void DrawLaser()
    {
        loopActive = true;
        int countLaser = 1;

        pos = transform.position;
        directLaser = transform.right;
        lineRenderer.positionCount = countLaser;
        lineRenderer.SetPosition(0, pos);

        while (loopActive)
        {
            var hit = Physics2D.Raycast(pos, directLaser, laserDistance);
            if (hit)
            {
                countLaser++;
                lineRenderer.positionCount = countLaser;
                directLaser = Vector3.Reflect(directLaser, hit.normal);
                pos = (Vector2)directLaser.normalized + hit.point;
                lineRenderer.SetPosition(countLaser - 1, hit.point);
            }
            else
            {
                countLaser++;
                lineRenderer.positionCount = countLaser;
                lineRenderer.SetPosition(countLaser - 1, pos + (directLaser.normalized * laserDistance));
                loopActive = false;
            }

            if (countLaser > numberReflectionMax)
            {
                loopActive = false;
            }
        }
    }
}
