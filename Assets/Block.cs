using UnityEngine;

public class Block : MonoBehaviour
{
    public int Points = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameController.Instance.AddScore(Points);
            Destroy(gameObject);
        }
    }
}