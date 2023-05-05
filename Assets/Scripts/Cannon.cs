using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private PlayerInput playerInput;

    [Header("Canon Variables")]
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        // Shoot the Canon With Player Input
        if (playerInput)
        {
            playerInput.ShootInput += FireCannon;
        }
    }

    // Create a Bullet To Fire
    private void FireCannon()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}