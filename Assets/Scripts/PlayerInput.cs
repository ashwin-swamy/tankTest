using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Players Enum
    private enum CurrentPlayer { player1, player2 };
    [SerializeField]
    CurrentPlayer player;

    // Instance of Player Controls Input Action Map
    private PlayerControls playerControls;

    // Values to Store Move and Rotate Input
    private float moveInput;
    private float rotationInput;

    // Delegate For Shooting Projectile
    public delegate void ShootDelegate();

    // Properties to Access Input Values
    public float MoveInput { get => moveInput; }
    public float RotationInput { get => rotationInput; }
    public ShootDelegate ShootInput { get; set; }

    private void Awake()
    {
        // Create References For the Three Input Actions
        playerControls = new PlayerControls();
        InputAction playerMove;
        InputAction playerRotate;
        InputAction playerShoot;

        // Check Player to Assign Controls
        if (player == CurrentPlayer.player1)
        {
            //Assign Controls for Player 1
            playerMove = playerControls.Player1.Move;
            playerRotate = playerControls.Player1.Rotate;
            playerShoot = playerControls.Player1.Shoot;
        }
        else
        {
            //Assign Controls for Player 2
            playerMove = playerControls.Player2.Move;
            playerRotate = playerControls.Player2.Rotate;
            playerShoot = playerControls.Player2.Shoot;
        }

        //Assign Move Value
        playerMove.performed += _ => Move(_.ReadValue<float>());
        playerMove.canceled += _ => Move(_.ReadValue<float>());

        //Assign Rotate Value
        playerRotate.performed += _ => Rotate(_.ReadValue<float>());
        playerRotate.canceled += _ => Rotate(_.ReadValue<float>());

        //Run Shoot Action
        playerShoot.performed += _ => Shoot();
    }

    // Move Input Value
    private void Move(float value)
    {
        moveInput = value;
    }

    // Rotate Input Value
    private void Rotate(float value)
    {
        rotationInput = value;
    }

    // Shoot Input
    private void Shoot()
    {
        ShootInput();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}