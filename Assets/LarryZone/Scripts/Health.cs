using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Player,
    Gorilla,
    Backpack
}

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public Image HealthBar;
    [SerializeField] float speedhealthBar_ = 2f;
    public CharacterType characterType;

    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (!isGamePaused)
        {
            UpdateHealthBar();
        }
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        Debug.Log("Me hicieron daño" + gameObject.name);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isGamePaused = true;
        Time.timeScale = 0f;

        switch (characterType)
        {
            case CharacterType.Player:
                Debug.Log("Player ha muerto");
                // Si el personaje que muere es el jugador, busca un objeto con tag "Lose" y actívalo
                GameObject loseObject = GameObject.FindGameObjectWithTag("Lose");
                if (loseObject != null)
                {
                    loseObject.SetActive(true);
                }
                break;

            case CharacterType.Gorilla:
                Debug.Log("Gorilla ha muerto");
                // Aquí puedes agregar el código específico para la muerte de la gorila
                break;

            case CharacterType.Backpack:
                Debug.Log("Backpack ha muerto");
                // Si el personaje que muere es el jugador, busca un objeto con tag "Lose" y actívalo
                GameObject loseObjectBackpack = GameObject.FindGameObjectWithTag("Lose");
                if (loseObjectBackpack != null)
                {
                    loseObjectBackpack.SetActive(true);
                }
                break;

            default:
                Debug.LogWarning("Tipo de personaje no reconocido");
                break;
        }
    }

    private void UpdateHealthBar()
    {
        if (HealthBar != null)
        {
            float targetFillAmount = (float)CurrentHealth / MaxHealth;
            float smoothedFillAmount = Mathf.MoveTowards(HealthBar.fillAmount, targetFillAmount, Time.deltaTime * speedhealthBar_);
            HealthBar.fillAmount = smoothedFillAmount;
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
}
