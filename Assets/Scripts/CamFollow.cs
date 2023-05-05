using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private Transform lookTarget;
    [Header("Look Variables")]
    [SerializeField]
    private float lookDistance = 6.0f;
    [SerializeField]
    private float lookHeight = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // Set the x and z position of th camera to the player
        Vector3 positionDifference = Direction.MoveDirection(lookTarget.eulerAngles.y) * lookDistance;
        // Set the height of the camera to the player
        Vector3 cameraHeight = Vector3.up * lookHeight;

        // Position the camera and look at the player
        transform.position = lookTarget.position - positionDifference + cameraHeight;
        transform.LookAt(lookTarget);
    }
}