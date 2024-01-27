using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount_ = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta según tus necesidades
        {
            // Aplica la regeneración de vida al jugador

            /*PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Heal(healAmount);
                Destroy(gameObject); // Destruye el botiquín después de ser recogido
            }*/

        }
    }
}
