using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private Transform lookTarget;
    [SerializeField]
    private float lookDistance = 6.0f;
    [SerializeField]
    private float lookHeight = 2.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionDifference = Direction.MoveDirection(lookTarget.eulerAngles.y) * lookDistance;
        Vector3 cameraHeight = Vector3.up * lookHeight;

        transform.position = lookTarget.position - positionDifference + cameraHeight;
        transform.LookAt(lookTarget);
    }
}