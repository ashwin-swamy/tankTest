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

    public float MoveInput { get => moveInput; }
    public float RotationInput { get => rotationInput; }

    private void Awake()
    {
        playerControls = new PlayerControls();
        InputAction playerMove;
        InputAction playerRotate;

        if (player == CurrentPlayer.player1)
        {
            //Assign Controls for Player 1
            playerMove = playerControls.Player1.Move;
            playerRotate = playerControls.Player1.Rotate;
        }
        else
        {
            //Assign Controls for Player 2
            playerMove = playerControls.Player2.Move;
            playerRotate = playerControls.Player2.Rotate;
        }

        //Assign Move Value
        playerMove.performed += _ => Move(_.ReadValue<float>());
        playerMove.canceled += _ => Move(_.ReadValue<float>());

        //Assign Rotate Value
        playerRotate.performed += _ => Rotate(_.ReadValue<float>());
        playerRotate.canceled += _ => Rotate(_.ReadValue<float>());
    }

    private void Move(float value)
    {
        moveInput = value;
    }

    private void Rotate(float value)
    {
        rotationInput = value;
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