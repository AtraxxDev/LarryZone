using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [SerializeField] private int damage_ = 10;

    public Animator animator;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisione2");
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            if (animator != null)
            {
                // Reproduce la animaci�n trigger
                animator.SetTrigger("Punch");
            }

            StartCoroutine(ApplyDamageAfterAnimation(damageable, damage_));

        }
    }

    private IEnumerator ApplyDamageAfterAnimation(IDamageable damageable, int damage)
    {
        yield return new WaitForSeconds(0.5f); // Ajusta el tiempo seg�n la duraci�n de tu animaci�n
        damageable.TakeDamage(damage);
        Debug.Log("Hice Da�o2");
    }

}
