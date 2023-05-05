using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;

    GameMenu menu;

    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        menu = FindFirstObjectByType<GameMenu>();
        menu.RestartGame += ResetHealth;

        currentHealth = maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Current Health {currentHealth}");

        if (currentHealth <= 0)
            menu.EndGame(gameObject.tag.ToString());
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Damage");
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            Debug.Log($"Damage: {projectile.Damage}");
            DamagePlayer(projectile.Damage);
        }
    }
}