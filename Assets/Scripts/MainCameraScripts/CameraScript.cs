using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    [SerializeField] private float newSize;

    private Camera camera;
    private float initialSize;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        initialSize = initialSize = camera.orthographicSize;
    }

    public void ChangeSize() => camera.orthographicSize = newSize;

    public void ReturnSize() => camera.orthographicSize = initialSize;
}