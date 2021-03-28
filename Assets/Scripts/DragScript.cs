using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private Vector3 transition;
    private RayReflector reflector;

    public void OnMouseDown()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transition = mousePos - transform.parent.position;
        reflector = transform.parent.GetComponent<RayReflector>();
    }

    public void OnMouseDrag()
    {
        var pos = transform.parent.position;
        var x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transition.x;
        transform.parent.position = new Vector3(x, pos.y);

        reflector.UpdateRay();
    }
}
