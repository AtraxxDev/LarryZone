using System.Collections;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount_ = 20;
    [SerializeField] private AudioClip pickupSound; // Agrega el sonido aquí

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                StartCoroutine(HealAndDestroy(playerHealth));
            }
        }
    }

    private IEnumerator HealAndDestroy(Health playerHealth)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
            yield return new WaitForSeconds(pickupSound.length);
        }

        playerHealth.Heal(healAmount_);
        Destroy(gameObject);
    }
}
