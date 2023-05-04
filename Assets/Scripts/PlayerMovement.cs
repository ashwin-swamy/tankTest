using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 24.0f;

    // Update is called once per frame
    void Update()
    {
        if (playerInput)
        {
            float newPlayerAngle = rotateSpeed * Time.deltaTime * playerInput.RotationInput + transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0.0f, newPlayerAngle, 0.0f);

            transform.position += Speed() * Direction.MoveDirection(newPlayerAngle);
        }
    }

    private float Speed()
    {
        return moveSpeed * Time.deltaTime * playerInput.MoveInput;
    }
}