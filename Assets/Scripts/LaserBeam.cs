using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    private Vector3 position, direction;
    private GameObject laserObj;
    private LineRenderer renderer;
    private List<Vector3> points = new List<Vector3>();

    public LaserBeam(Vector3 pos, Vector3 dir, Material mat)
    {
        renderer = new LineRenderer();
        laserObj = new GameObject("Laser Beam");
        position = pos;
        direction = dir;

        renderer = laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        renderer.startWidth = 0.1f;
        renderer.endWidth = 0.1f;
        renderer.material = mat;
        renderer.startColor = Color.green;
        renderer.endColor = Color.green;

        CastRay(position, direction);
    }

    private void CastRay(Vector3 pos, Vector3 dir)
    {
        points.Add(pos);

        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 30);

        if (hit)
        {
            CheckHit(hit, dir);
        } else
        {
            points.Add(pos * 30);
            UpdateLaser();
        }
    }

    private void CheckHit(RaycastHit2D hitInfo, Vector3 direction)
    {
        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir);
        } else
        {
            points.Add(hitInfo.point);
            UpdateLaser();
        }
    }

    private void UpdateLaser()
    {
        int count = 0;
        renderer.positionCount = points.Count;

        foreach (var item in points)
        {
            renderer.SetPosition(count, item);
            count++;
        }
    }

    public void Refresh(Vector3 pos, Vector3 dir)
    {
        position = pos;
        direction = dir;
        CastRay(pos, dir);
    }
}
