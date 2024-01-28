using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage_ = 10;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisione");
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && other.tag != "Player")
        {
            damageable.TakeDamage(damage_);
            Debug.Log("Hice Daño");
            Destroy(gameObject);
        }
    }
}
