using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public AudioSource pauseSound; // Asegúrate de asignar un AudioSource en el Inspector
    private bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        ActivatePauseObject(true);
        PlayPauseSound();
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        ActivatePauseObject(false);
        PlayPauseSound();
    }

    void ActivatePauseObject(bool activate)
    {
        GameObject pauseObject = GameObject.FindGameObjectWithTag("Pause");
        if (pauseObject != null)
        {
            pauseObject.SetActive(activate);
        }
    }

    void PlayPauseSound()
    {
        if (pauseSound != null)
        {
            pauseSound.Play();
        }
    }

    public void RestartScene()
    {
        // Obtener el nombre de la escena actual y cargarla
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadScene(string sceneName)
    {
        // Cargar la escena por su nombre
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        // Salir de la aplicación
        Application.Quit();
    }
}
