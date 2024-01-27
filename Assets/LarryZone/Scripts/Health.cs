using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{

    [SerializeField] private int maxHealth_ = 100;
    [SerializeField] private int currentHealth_;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth_ = maxHealth_;
    }

    public void TakeDamage(int amount)
    {
        currentHealth_ -= amount;

        if (currentHealth_ <= 0) 
        {
            Die();
        }
    }

    public void Die()
    {
        // reproducir animacion de muerte y su logica de este objeto

    }

}
