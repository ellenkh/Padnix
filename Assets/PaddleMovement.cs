using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the paddle movement
    public float minX = -2f;// Minimum X position for the paddle
    public float maxX = 2f; // Maximum X position for the paddle

    private void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f; // Move left
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;// Move right
        }

        transform.Translate(move * speed * Time.deltaTime * Vector3.right);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

}


