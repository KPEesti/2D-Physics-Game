using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    [SerializeField] private float newSize;
    [SerializeField] private float initialSize;

    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public void ChangeCameraSize() => camera.orthographicSize = newSize;

    public void ReturnCameraSize() => camera.orthographicSize = initialSize;
}
