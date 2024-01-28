using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioClip[] songs; // Lista de sonidos
    private AudioSource audioSource;
    public float minDelay = 5f; // Retraso mínimo entre reproducciones
    public float maxDelay = 10f; // Retraso máximo entre reproducciones

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSong());
    }

    IEnumerator PlayRandomSong()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            // Reproduce un sonido aleatorio de la lista
            if (songs.Length > 0)
            {
                int randomIndex = Random.Range(0, songs.Length);
                audioSource.clip = songs[randomIndex];
                audioSource.Play();
            }
        }
    }
}
