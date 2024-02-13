using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / fireRate;
        }
        if (isAuto)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && timer <= 0)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Replace in the inspector the bullet by bubbles
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (bulletSpawnTransform.forward * bulletSpeed);
        timer = 1;
    }

}
