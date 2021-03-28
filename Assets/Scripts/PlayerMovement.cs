using UnityEngine;
using static Lever;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private bool facingRight;
    private float horizontalMovement;
    private Transform player;

    private void Start()
    {
        facingRight = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        player.localScale = new Vector2(-player.localScale.x, player.localScale.y);
    }

    public void Rofl() => Debug.Log("все работает ауе");
}
