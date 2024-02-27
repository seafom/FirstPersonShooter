using System.Collections;
using System.Collections.Generic;
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
                Instantiate(SmokeParticle, bulletSpawnTransform.position, bulletSpawnTransform.rotation); 
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
        bullet.GetComponent<Rigidbody>().velocity = (bulletSpawnTransform.forward * bulletSpeed);
        shake.StartCoroutine(shake.Shake(0.1f, 0.1f));
    }







}
