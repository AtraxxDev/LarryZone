using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedBoost_ = 2.0f;
    [SerializeField] private float duration_ = 5.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta según tus necesidades
        {
            // Aplica el power-up al jugador

            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ApplySpeedBoost(speedBoost_, duration_);
                Destroy(gameObject); // Destruye el power-up después de ser recogido
            }

        }
    }


   
}
