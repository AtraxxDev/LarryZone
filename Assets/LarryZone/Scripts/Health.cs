using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{

     public int MaxHealth = 100;
     public int CurrentHealth;
     public Image HealthBar;
    [SerializeField] float speedhealthBar_ = 2f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        
    }

    private void Update()
    {
        UpdateHealthBar();
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
        // reproducir animacion de muerte y su logica de este objeto

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
