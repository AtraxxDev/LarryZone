using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    
}
