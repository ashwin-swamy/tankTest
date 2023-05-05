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
        menu = FindFirstObjectByType<GameMenu>();
        menu.RestartGame += ResetHealth;

        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        Debug.Log((float)(currentHealth / maxHealth));
        healthBar.fillAmount = (currentHealth / maxHealth);
        Debug.Log($"Current Health {currentHealth}");

        if (currentHealth <= 0)
            menu.EndGame(gameObject.tag.ToString());
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            DamagePlayer(projectile.Damage);
        }
    }
}