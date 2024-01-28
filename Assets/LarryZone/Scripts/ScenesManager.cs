using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    public AudioSource pauseSound; // Asegúrate de asignar un AudioSource en el Inspector
    public AudioSource MusicLevel;
    public AudioSource LoseSound;
    private bool isGamePaused = false;

    void Awake()
    {
        // Asegurar que solo haya una instancia del ScenesManager
        if (Instance == null)
        {
            Instance = this;
            
        }
        
    }
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
        MusicLevel.Pause();
        ActivatePauseObject(true);
        PlayPauseSound();
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        MusicLevel.UnPause();
        ActivatePauseObject(false);
        PlayPauseSound();
    }

    void ActivatePauseObject(bool activate)
    {
        GameObject pauseObject = GameObject.FindGameObjectWithTag("Pause");

        if (pauseObject != null)
        {

            // Busca el objeto hijo con el nombre "NombreDelHijo" y actívalo/desactívalo
            Transform childTransform = pauseObject.transform.Find("PanelPause");
            if (childTransform != null)
            {
                childTransform.gameObject.SetActive(activate);
            }
        }
    }

    void PlayPauseSound()
    {
        if (pauseSound != null)
        {
            pauseSound.Play();
        }
    }
    public void GameOver()
    {
        if (MusicLevel != null)
        {
            MusicLevel.Stop();
        }

        if (LoseSound != null)
        {
            LoseSound.Play();
        }
       
    }

    public void RestartScene()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        // Obtener el nombre de la escena actual y cargarla
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadScene(string sceneName)
    {
        isGamePaused = false;
        Time.timeScale = 1;
        // Cargar la escena por su nombre
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        // Salir de la aplicación
        Application.Quit();
    }
}
