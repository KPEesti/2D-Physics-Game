using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaserSource : MonoBehaviour
{
    public int numberReflectionMax = 5;

    [HideInInspector]
    public GameObject lastRaycastedObject;

    private LineRenderer lineRenderer;
    private int laserDistance = 100;
    private Vector3 pos = new Vector3();
    private Vector3 directLaser = new Vector3();

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
        int countLaser = 1;

        pos = transform.position;
        directLaser = transform.right;
        lineRenderer.positionCount = countLaser;
        lineRenderer.SetPosition(0, pos);

        while (true)
        {
            var hit = Physics2D.Raycast(pos, directLaser, laserDistance, 1 << LayerMask.GetMask("Defualt"));
            if (hit)
            {
                countLaser++;
                lineRenderer.positionCount = countLaser;
                directLaser = Vector3.Reflect(directLaser, hit.normal);
                // передвигаем новую стартовую точку чуть вперед по отраженному направлению, так как она может оказаться
                // внутри объекта из-за погрешности вычислений
                pos = (Vector2)directLaser.normalized + hit.point;
                lineRenderer.SetPosition(countLaser - 1, hit.point); // при этом рисуем точку касания без изменений

                lastRaycastedObject = hit.collider.gameObject;
                Debug.Log("Last raycasted obj: "+lastRaycastedObject.name);
            }
            else
            {
                countLaser++;
                lineRenderer.positionCount = countLaser;
                lineRenderer.SetPosition(countLaser - 1, pos + (directLaser.normalized * laserDistance));
                break;
            }

            if (countLaser > numberReflectionMax || !hit.collider.tag.Equals("Mirror"))
                break;
        }
    }
}
