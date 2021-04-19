using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaserSource : MonoBehaviour
{
    public int reflectedRaysAmount = 2;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, new Vector3(0, 0, 0));
    }

    void Update()
    {
        // всегда в Raycast передаем все векторы в world space
        var pos = transform.TransformPoint(line.GetPosition(0));
        var dir = transform.right.normalized;
        float distance = 30;

        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance);

        if (hit)
        {
            Vector2 p = transform.InverseTransformPoint(hit.point);
            //p.y = 0;
            //p.z = 0;
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
            line.SetPosition(1, new Vector3(distance, 0, 0));
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
        /*Vector2 vector = transform.TransformPoint(line.GetPosition(1))
                    - transform.TransformPoint(line.GetPosition(0));

                Vector2 refDir = Vector2.Reflect(vector.normalized, hit.normal);
                Debug.Log("Vector: "+hit.normal.ToString());

                Vector2 start = line.GetPosition(1);

                // сначала переводим точки из систему в систему, потом только вычитаем
                Vector3 reflectedW = transform.InverseTransformPoint(refDir)
                    - transform.InverseTransformPoint(new Vector3(0, 0, 0));

                line.positionCount = 3;
                line.SetPosition(2, (Vector3) start + reflectedW * 30);*/

        var refl = reflectedRaysAmount - 1;
        var index = 2;
        RaycastHit2D curHit = hit;

        line.positionCount = 2 + refl;

        while (refl > 0)
        {
            Vector2 startW = transform.TransformPoint(line.GetPosition(index - 1));
            Vector2 vectorW = transform.TransformPoint(line.GetPosition(index - 1))
                - transform.TransformPoint(line.GetPosition(index - 2));

            Vector2 reflectedW = Vector2.Reflect(vectorW.normalized, curHit.normal);
            var raycastW = Physics2D.Raycast(startW, reflectedW.normalized, 30);

            if (raycastW)
            {
                curHit = raycastW;
                Vector2 newPointW = raycastW.point;
                line.SetPosition(index, transform.InverseTransformPoint(newPointW));
                index++;

                if (raycastW.collider.tag != "Mirror") break;
            }
            else
            {
                Vector3 reflectedL = transform.InverseTransformPoint(reflectedW)
                    - transform.InverseTransformPoint(new Vector3(0, 0, 0));
                Vector2 s = line.GetPosition(index - 1);
                line.SetPosition(index, (Vector3) s + reflectedL * 30);
                line.positionCount = index + 1;
                break;
            }

            refl--;
        }
    }
}
