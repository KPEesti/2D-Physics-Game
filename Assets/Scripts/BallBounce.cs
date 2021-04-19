using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(100f, 100f));
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = velocity.magnitude;

        var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rigidbody2D.velocity = direction * Mathf.Max(speed, 3f);
    }
}
