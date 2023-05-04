using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private const float rad = Mathf.Deg2Rad;

    [SerializeField]
    private Transform lookTarget;
    [SerializeField]
    private float lookDistance = 6.0f;
    [SerializeField]
    private float cameraHeight = 2.0f;

    private void Start()
    {
        Debug.Log(Mathf.Cos(lookTarget.eulerAngles.y * Mathf.Deg2Rad));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = lookTarget.position - (Vector3.back * -10.0f);
        transform.position = lookTarget.position - LookPosition();
        transform.LookAt(lookTarget);
    }

    private Vector3 LookPosition()
    {
        float currentAngle = lookTarget.eulerAngles.y * rad;
        float camZ = Mathf.Sin(currentAngle) * -lookDistance;
        float camX = Mathf.Cos(currentAngle) * lookDistance;
        return new Vector3(camX, -cameraHeight, camZ);
    }
}
