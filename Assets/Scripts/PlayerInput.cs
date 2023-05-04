using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private enum CurrentPlayer { player1, player2 };

    private PlayerControls playerControls;
    private float moveInput;
    private float rotationInput;

    [SerializeField]
    CurrentPlayer player;

    public delegate void ShootDelegate();

    public float MoveInput { get => moveInput; }
    public float RotationInput { get => rotationInput; }

    public ShootDelegate ShootInput { get; set; }

    private void Awake()
    {
        playerControls = new PlayerControls();
        InputAction playerMove;
        InputAction playerRotate;
        InputAction playerShoot;

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

    private void Move(float value)
    {
        moveInput = value;
    }

    private void Rotate(float value)
    {
        rotationInput = value;
    }

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