using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    public Animator animator;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    [SerializeField] GameObject SmokeParticle;
    [SerializeField] GameObject BubblepopParticle;
    
    [SerializeField] CameraShake shake;
    [SerializeField] private float _damage;

    private void Start()
    {

    }

    private void Update()
    {
            if (Input.GetButton("Fire1"))
            {
                animator.SetTrigger("GetButtonDown");
                Shoot();

            }
        if (Input.GetButtonUp("Fire1"))
        {
                animator.SetTrigger("GetButtonUp");
        }
    }


    void Shoot()
    {
        // Replace in the inspector the bullet by bubbles
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        Instantiate(SmokeParticle, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        Instantiate(BubblepopParticle, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (bulletSpawnTransform.forward * bulletSpeed);
        shake.StartCoroutine(shake.Shake(0.1f, 0.1f));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            if (raycastHit.collider.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(1000f, raycastHit.point, 5f);
            }
            if (raycastHit.collider.gameObject.TryGetComponent<Damageable>(out Damageable damageable)) 
            {
                damageable.Damage(33);
            }
        }
    }







}
