using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeprecatedLaserSource : MonoBehaviour
{
    public int reflectedRaysAmount = 2;
    public float distance = 30;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
    }

    void Update()
    {
        // всегда в Raycast передаем все векторы в world space
        var pos = transform.position;
        var dir = transform.right;

        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance);

        if (hit)
        {
            Vector3 p = hit.point;
            line.SetPosition(1, p);

            if (hit.collider.tag == "Mirror")
            {
                GenReflection(hit);
            }
        }
    }

    Vector3[] GetStandartLine()
    {
        line.positionCount = 2;
        return new Vector3[] { line.GetPosition(0), line.GetPosition(1) };
    }

    void GenReflection(RaycastHit2D hit)
    {
        var refl = reflectedRaysAmount - 1;
        var index = 2;
        //RaycastHit2D curHit = hit;
        Vector2 normal = hit.normal;

        line.positionCount = 2 + refl;

        while (refl > 0)
        {
            Vector2 startW = line.GetPosition(index - 1);
            Vector2 vectorW = line.GetPosition(index - 1) - line.GetPosition(index - 2);

            Vector2 reflectedW = Vector2.Reflect(vectorW.normalized, normal);
            var raycastW = Physics2D.Raycast(startW, reflectedW.normalized, 30);

            if (raycastW)
            {
                //curHit = raycastW;
                normal = raycastW.normal;
                Vector3 newPointW = new Vector3(raycastW.point.x, raycastW.point.y, 0);
                line.SetPosition(index, newPointW);
                index++;

                if (raycastW.collider.tag != "Mirror") break;
            }
            else
            {
                Vector3 s = line.GetPosition(index - 1);

                var newPos = s + (Vector3) reflectedW * 30;
                newPos.z = 0;
                line.SetPosition(index, newPos);
                line.positionCount = index + 1;
                break;
            }

            refl--;
        }
    }
}
