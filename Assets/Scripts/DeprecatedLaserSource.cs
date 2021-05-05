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

            } else
            {
                line.SetPositions(GetStandartLine());
            }
        } else
        {
            line.SetPosition(1, pos + transform.right * distance);
            line.SetPositions(GetStandartLine());
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
            Vector2 startW = transform.TransformPoint(line.GetPosition(index - 1));
            Vector2 vectorW = transform.TransformPoint(line.GetPosition(index - 1))
                - transform.TransformPoint(line.GetPosition(index - 2));

            Vector2 reflectedW = Vector2.Reflect(vectorW.normalized, normal);
            var raycastW = Physics2D.Raycast(startW, reflectedW.normalized, 30);

            if (raycastW)
            {
                //curHit = raycastW;
                normal = raycastW.normal;
                Debug.Log("Normal: "+normal);
                Vector3 newPointW = new Vector3(raycastW.point.x, raycastW.point.y, 0);
                line.SetPosition(index, transform.InverseTransformPoint(newPointW));
                index++;

                if (raycastW.collider.tag != "Mirror") break;
            }
            else
            {
                Vector3 reflectedL = transform.InverseTransformPoint(reflectedW)
                    - transform.InverseTransformPoint(new Vector3(0, 0, 0));
                Vector3 s = line.GetPosition(index - 1);

                var newPos = s + reflectedL * 30;
                newPos.z = 0;
                line.SetPosition(index, newPos);
                line.positionCount = index + 1;
                break;
            }

            refl--;
        }
    }
}
