using UnityEngine;

public static class Direction
{
    public const float rad = Mathf.Deg2Rad;

    // Caulculate direction of Movement based on Rotation
    public static Vector3 MoveDirection(float rotateAngle)
    {
        float angle = rotateAngle * rad;
        float front = -Mathf.Sin(angle);
        float side = Mathf.Cos(angle);

        return new Vector3(side, 0.0f, front);
    }
}