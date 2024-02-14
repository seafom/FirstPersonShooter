using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject ExplosionParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Instantiate(ExplosionParticle, gameObject.transform.position, gameObject.transform.rotation);
               //Destroy(gameObject);
        }         
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
