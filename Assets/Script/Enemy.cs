using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float initialHealth = 100f;

    [SerializeField] GameObject FloatingTextPrefab;
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
                Destroy(gameObject);
            }
            if (FloatingTextPrefab)
            {
                ShowFloatingText();
            }
        }
    }


    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
    }

   void ShowFloatingText()
   {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
   }
}