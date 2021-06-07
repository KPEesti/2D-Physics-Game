using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float Start;
    [SerializeField] public float End;

    private void FixedUpdate()
    {
        transform.position += new Vector3(1, 0, 0) * Speed;
        if (transform.position.x > End) 
            transform.position = new Vector3(Start, transform.position.y, transform.position.z);
    }
}
