using System.Collections;using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15.0f;
    [SerializeField]
    private int damage = 2;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Direction.MoveDirection(transform.eulerAngles.y);
    }
}