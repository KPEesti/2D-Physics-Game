using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    [SerializeField] private float size;
    private float initialSize;
    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        initialSize = camera.orthographicSize;
    }

    public void ChangeCameraSize() => camera.orthographicSize = size;

    public void ReturnCameraSize() => camera.orthographicSize = initialSize;
}
