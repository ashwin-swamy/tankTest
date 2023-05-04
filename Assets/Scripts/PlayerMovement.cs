using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float rad = Mathf.Deg2Rad;

    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 24.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Speed() * MoveDirection();
    }

    private float Speed()
    {
        if (playerInput)
        {
            return moveSpeed * Time.deltaTime * playerInput.MoveInput;
        }
        else
        {
            return 0.0f;
        }
    }

    private Vector3 MoveDirection()
    {
        if (playerInput)
        {
            float newAngle = rotateSpeed * Time.deltaTime * playerInput.RotationInput + transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0.0f, newAngle, 0.0f);

            float angle = transform.eulerAngles.y * rad;
            float front = -Mathf.Sin(angle);
            float side = Mathf.Cos(angle);

            return new Vector3(side, 0.0f, front);
        }
        else
        {
            return Vector3.zero;
        }
    }
}