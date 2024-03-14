using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float initialHealth = 100f;
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] private Transform pfEnemyBroken;

    private float currentHealth;
    private int hitsTaken = 0; // Track the number of hits taken

    private void Start()
    {
        currentHealth = initialHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                ApplyDamage(bullet.GetDamage());
                ShowFloatingText();

                if (currentHealth <= 0)
                {
                    DestroyEnemy();
                }
            }
        }
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
    }

    void ShowFloatingText()
    {
        var damage = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        Destroy(damage, 1f); // Destroy the floating text after 1 second
    }

    void DestroyEnemy()
    {
        hitsTaken++; // Increment hits taken
        if (hitsTaken >= 3) // Check if the enemy has been hit 3 times
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(pfEnemyBroken, transform.position, Quaternion.identity);
            // Update score when enemy is destroyed
            ScoreManager.instance.UpdateScore(1);
            Destroy(gameObject); // Destroy the enemy object
        }
        else
        {
            // Reset health for next hit
            currentHealth = initialHealth;
        }
    }
}