using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D rb;
    private bool isLaunched = false;
    private Transform paddle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle").transform;
        rb.linearVelocity = Vector2.zero;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeathZone")
        {
            GameController.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}