using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount_ = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta seg�n tus necesidades
        {
            // Aplica la regeneraci�n de vida al jugador

            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount_);
                Destroy(gameObject); // Destruye el botiqu�n despu�s de ser recogido
            }

        }
    }
}
