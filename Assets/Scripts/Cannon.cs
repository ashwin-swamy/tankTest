using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        if (playerInput)
        {
            playerInput.ShootInput += FireCannon;
        }
    }

    private void FireCannon()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}