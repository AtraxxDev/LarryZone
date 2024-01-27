using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isPunching = false; 
    [SerializeField] private int _damage;

    [SerializeField] private float damageInterval = 0.5f; 



    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !isPunching)
        {
            isPunching = true;

            // Reproduce la animación de golpe si hay un componente Animator
            if (animator != null)
            {
                Debug.Log("Reproduzco animacion");
                animator.SetBool("Punch", true);
            }

            // Inicia la corrutina para aplicar daño cada cierto intervalo mientras se mantiene la colisión
            StartCoroutine(ApplyDamageRepeatedly(damageable));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPunching = false; // Se restablece cuando deja de haber colisión para permitir otro golpe
        animator.SetBool("Punch", false);
    }

    private System.Collections.IEnumerator ApplyDamageRepeatedly(IDamageable damageable)
    {
        while (isPunching)
        {
            damageable.TakeDamage(_damage); // Aplica el daño (ajusta según tus necesidades)
            yield return new WaitForSeconds(damageInterval);
        }
    }

}
