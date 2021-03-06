using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform leg;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator animator;

    private bool facingRight;
    private float horizontalMovement;
    private Transform player;
    private Rigidbody2D rigidbody;
    private bool isGrounded;

    private void Start()
    {
        facingRight = true;
        player = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        JumpLogic();

        if (horizontalMovement < 0 && facingRight || horizontalMovement > 0 && !facingRight)
            Flip();

        animator.SetBool("IsMoving", horizontalMovement != 0);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontalMovement * speed, rigidbody.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
    }

    private void JumpLogic()
    {
        isGrounded = Physics2D.OverlapCircle(leg.position, 0.4f, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded)
            rigidbody.velocity = Vector2.up * jumpForce;

        animator.SetBool("IsGrounded", isGrounded);
    }

    public void TestTrigger()
    {
        Debug.Log("Игрок вошёл в триггер");
    }
}
