using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    public float enemyPoints = 0f;
    public float playerPoints = 0f;

    //Texts
    [SerializeField] private TMP_Text botText;
    [SerializeField] private TMP_Text playerText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, Random.Range(-2f, 2f)).normalized * speed; // Randomize initial direction
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D paddleRb = collision.gameObject.GetComponent<Rigidbody2D>();
            float paddleSpeed = paddleRb.velocity.y; // Get paddle's movement speed

            float ballY = transform.position.y;
            float paddleY = collision.transform.position.y;
            float hitFactor = (ballY - paddleY) / (collision.collider.bounds.size.y / 2);

            float newDirectionX = rb.velocity.x > 0 ? -1 : 1; // Flip X direction

            // Add paddle's movement to the ball's Y velocity
            Vector2 newVelocity = new Vector2(newDirectionX, hitFactor + paddleSpeed * 0.5f).normalized * speed;

            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Eside"))
        {
            enemyPoints++;
            botText.text = "Bot: " + enemyPoints;
            RestartLevel();
        }

        if (collision.gameObject.CompareTag("Pside"))
        {
            playerPoints++;
            playerText.text = "Player: " + playerPoints;
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rb.velocity = new Vector2(speed, Random.Range(-2f, 2f)).normalized * speed; // Randomize initial direction
    }
}
