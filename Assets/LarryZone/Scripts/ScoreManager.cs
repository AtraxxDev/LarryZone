using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private static ScoreManager instance;

    private static int score;
    private static string scoreString;
    private static int highScore;
    private static string highScoreString;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int enemyScoreValue;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Si la instancia no existe, intenta encontrarla en la escena
                instance = FindObjectOfType<ScoreManager>();

                // Si no se encuentra, crea un nuevo objeto para la instancia
                if (instance == null)
                {
                    GameObject go = new GameObject("ScoreManager");
                    instance = go.AddComponent<ScoreManager>();
                }
            }

            return instance;
        }
    }

    void Start()
    {
        LoadHighScore();
        score = 0;
        scoreString = "00000";
        
    }

    // Update is called once per frame
    void Update()
    {
        OrderNumbers();
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "HI: " + highScoreString + "  " + scoreString;
    }
    private void OrderNumbers()
    {
        scoreString = score.ToString().Length switch
        {
            1 => "0000" + score,
            2 => "000" + score,
            3 => "00" + score,
            4 => "0" + score,
            5 => score.ToString(),
            _ => scoreString
        };
        highScoreString = highScore.ToString().Length switch
        {
            1 => "0000" + highScore,
            2 => "000" + highScore,
            3 => "00" + highScore,
            4 => "0" + highScore,
            5 => highScore.ToString(),
            _ => highScoreString
        };
    }
    public void IncreaseScore()
    {
        score+=enemyScoreValue;
        if (score <= highScore) return;
        highScore = score;
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    
}
