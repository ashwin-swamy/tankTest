using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    [Header("Movement Variables")]
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 24.0f;

    private Vector3 startPosition;
    private Vector3 startRotation;

    public GameMenu menu;

    private void Start()
    {
        // Restart Game Delegate
        menu = FindFirstObjectByType<GameMenu>();
        menu.RestartGame += RestartGame;

        // Save Initial Position of Player
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput)
        {
            // Use Rotation Input to Calculate New Angle of Player
            float newPlayerAngle = rotateSpeed * Time.deltaTime * playerInput.RotationInput + transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0.0f, newPlayerAngle, 0.0f);

            //Move the Player
            transform.position += Speed() * Direction.MoveDirection(newPlayerAngle);
        }
    }

    // Use Move Input to Set Player Move Speed
    private float Speed()
    {
        return moveSpeed * Time.deltaTime * playerInput.MoveInput;
    }

    // Add to Restart Game Delegate
    public void RestartGame()
    {
        transform.position = startPosition;
        transform.eulerAngles = startRotation;
    }
}