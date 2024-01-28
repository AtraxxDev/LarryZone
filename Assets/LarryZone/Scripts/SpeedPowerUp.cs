using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedBoost_ = 2.0f;
    [SerializeField] private float duration_ = 5.0f;
    [SerializeField] private AudioClip pickupSound; // Agrega el sonido aquí

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                StartCoroutine(ApplySpeedBoostAndDestroy(player));
            }
        }
    }

    private IEnumerator ApplySpeedBoostAndDestroy(PlayerMovement player)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null && pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
            yield return new WaitForSeconds(pickupSound.length);
        }

        player.ApplySpeedBoost(speedBoost_, duration_);
        Destroy(gameObject);
    }
}
