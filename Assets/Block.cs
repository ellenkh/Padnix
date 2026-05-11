using UnityEngine;

public class Block : MonoBehaviour
{
    public int BasePoints = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameController.Instance.IncrementCombo();
            int points = BasePoints * GameController.Instance.GetCombo();
            GameController.Instance.AddScore(points);
            Invoke("CheckWinDelay", 0.1f);
            Destroy(gameObject);
        }
    }
}