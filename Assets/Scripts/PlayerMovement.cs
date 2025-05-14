using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 6.0f;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1) // Left
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        
        if (Input.GetAxisRaw("Horizontal") == 1) // Right
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.velocity = Vector2.up * 0.8f * jumpForce;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
