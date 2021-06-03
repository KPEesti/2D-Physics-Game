using System;
using UnityEngine;
using static Lever;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform leg;
    [SerializeField] private LayerMask whatIsGround;

    private bool facingRight;
    private float horizontalMovement;
    private Transform player;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        facingRight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TestEvent()//не нужный метод, он здесь для тестирования event-ов
    {
        Debug.Log("event is working");
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(leg.position, 0.4f, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.velocity = Vector2.up * jumpForce;

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
        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
    }

    public void TestTrigger()
    {
        Debug.Log("Игрок вошёл в триггер");
    }
}
