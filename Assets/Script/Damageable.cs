using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] GameObject _explosion;
    [SerializeField] float _initialHealth;

    private float _currentHealth;


    private void Awake()
    {
        _currentHealth = _initialHealth;
    }


    public void ApplyDamage(float damage)
    {
        if (_currentHealth < 0) return;

        _currentHealth -= damage;

        if(_currentHealth < 0)
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
