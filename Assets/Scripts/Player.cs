using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool facingRight;
    private float horizontalMovement;

    private void Start()
    {
        facingRight = true;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement < 0 && facingRight || horizontalMovement > 0 && !facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * speed;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
