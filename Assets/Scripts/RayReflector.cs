using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RayReflector : MonoBehaviour
{
    public GameObject lamp;
    public GameObject line;
    public GameObject window;
    public Color greenColor;

    private LineRenderer lineRenderer;
    private SpriteRenderer windowSpriteRenderer;
    private Color standartWindowColor;

    void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        windowSpriteRenderer = window.GetComponent<SpriteRenderer>();
        standartWindowColor = windowSpriteRenderer.color;
    }

    public void UpdateRay()
    {
        lineRenderer.SetPosition(1, line.transform.InverseTransformPoint(transform.position));

        var vectorFromSource = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);

        var refVectorX = Math.Abs(vectorFromSource.x);
        var direction = new Vector3(lineRenderer.GetPosition(1).x + refVectorX, lineRenderer.GetPosition(0).y, 0) * 2;

        var dirToPos1 = direction - lineRenderer.GetPosition(1);
        var directionWorld = lineRenderer.transform.TransformPoint(dirToPos1);
        var hit = Physics2D.Raycast(lineRenderer.GetPosition(1), directionWorld.normalized, directionWorld.magnitude);

        /*lineRenderer.SetPosition(2, direction);
        DebugAngles();*/

        if (hit)
        {
            if (!hit.collider.isTrigger)
            {
                lineRenderer.SetPosition(2, line.transform.InverseTransformPoint(hit.point));
                DebugAngles();
            }

            if (hit.collider.name == "WindowCollider")
                windowSpriteRenderer.color = greenColor;
            else
                windowSpriteRenderer.color = standartWindowColor;
        }
    }

    public void DebugAngles()
    {
        var v01 = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
        var v12 = lineRenderer.GetPosition(2) - lineRenderer.GetPosition(1);

        var angle1 = Math.PI - Math.Atan2(v01.y, v01.x);
        var angle2 = Math.Atan2(v12.y, v12.x);

        Debug.Log(String.Format("AngleA = {0}, AngleB = {1}", angle1, angle2));
    }

    void Update()
    {
        
    }
}
