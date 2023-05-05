using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Variables")]
    [SerializeField]
    private float moveSpeed = 15.0f;
    [SerializeField]
    private int damage = 2;
    [SerializeField]
    private float timer = 5.0f;

    // Access Projectile Damage
    public int Damage { get => damage; }

    // Update is called once per frame
    void Update()
    {
        // Move the Projectile Until the Timer Runs Out
        transform.position += moveSpeed * Time.deltaTime * Direction.MoveDirection(transform.eulerAngles.y);
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    // Destroy the Projectile When It Hits Something
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}