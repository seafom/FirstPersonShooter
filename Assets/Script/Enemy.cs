using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float initialHealth = 100f;
    [SerializeField] GameObject floatingTextPrefab;

    private float currentHealth;

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
            }

            if (currentHealth <= 0)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                ShowFloatingText();
                Destroy(gameObject);
                // Update score when enemy is destroyed
                ScoreManager.instance.UpdateScore(1); 
            }
        }
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
    }

    void ShowFloatingText()
    {
        Instantiate(floatingTextPrefab, transform.position, transform.rotation);
    }
}