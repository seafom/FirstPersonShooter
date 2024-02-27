using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject explosionParticle;
    [SerializeField] float _damage = 10f;

    public float GetDamage()
    {
        return _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag("Player")) // Avoid destroying the bullet when colliding with the player
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}