using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 10.0f;
    [SerializeField]
    private Image healthBar;

    private GameMenu menu;

    private float currentHealth;

    // Use this for initialization
    void Start()
    {
        // Add to Restart Game Delegate
        menu = FindFirstObjectByType<GameMenu>();
        menu.RestartGame += ResetHealth;

        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f;
    }

    // Damage the Player and Check Health
    public void DamagePlayer(int damage)
    {
        // Update Health and Health Bar
        currentHealth -= damage;
        healthBar.fillAmount = (currentHealth / maxHealth);

        // If Health 0 Player Loses
        if (currentHealth <= 0)
            menu.EndGame(gameObject.tag.ToString());
    }

    // Add to Restart Game Delegate
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check If Bullet Hit Player
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Damage the Player
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            DamagePlayer(projectile.Damage);
        }
    }
}