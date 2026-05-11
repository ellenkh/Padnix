using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float SpeedIncrease = 0.2f;
    public float MaxSpeed = 15f;

    private Rigidbody2D rb;
    private bool isLaunched = false;
    private Transform paddle;
    private float currentSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle").transform;
        rb.linearVelocity = Vector2.zero;
        currentSpeed = Speed;
    }

    void Update()
    {
        if (!isLaunched)
        {
            // Følg padlen
            Vector3 paddlePos = paddle.position;
            transform.position = new Vector3(paddlePos.x, paddlePos.y + 0.5f, 0f);

            // Trykk space for å skyte
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isLaunched = true;
                rb.linearVelocity = new Vector2(1, 1).normalized * Speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;

        // Treffer paddle eller vegg = reset combo
        if (name == "Paddle" || name.Contains("Wall"))
        {
            GameController.Instance.ResetCombo();
        }

        // Øk farten gradvis ved hver kollisjon
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedIncrease;
            rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeathZone")
        {
            GameController.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}