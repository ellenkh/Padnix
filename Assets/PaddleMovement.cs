using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the paddle movement
    public float minX = -4.5f;
    public float maxX = 4.5f;

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


