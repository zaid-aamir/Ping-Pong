using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, Random.Range(-2f, 2f)).normalized * speed; // Randomize initial direction
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            // Get ball and paddle positions
            float ballY = transform.position.y;
            float paddleY = collision.transform.position.y;
            float hitFactor = (ballY - paddleY) / (collision.collider.bounds.size.y / 2);

            // Adjust X direction and add spin based on hit position
            float newDirectionX = rb.velocity.x > 0 ? -1 : 1; // Flip X direction
            Vector2 newVelocity = new Vector2(newDirectionX, hitFactor).normalized * speed;

            rb.velocity = newVelocity;
        }

        //if(collision.gameObject.CompareTag())
    }
}
