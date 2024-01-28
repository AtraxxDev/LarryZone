using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] private Health _health;
    public float speed;
    public float stoppingDistance; // Nueva variable para la distancia de parada
    private bool isTargetReached = false; // Nueva variable para verificar si se alcanzó el objetivo
    private SpriteRenderer spriteRenderer; // Variable para almacenar el componente SpriteRenderer

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Backpack");
        _health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtén el componente SpriteRenderer
        FlipSpriteIfNeeded(); // Llama a la función para voltear el sprite si es necesario
    }

    void Update()
    {
        if (!isTargetReached)
        {
            MoveTowardsBackpack();
        }

        Die();
    }

    private void Die()
    {
        if (_health.CurrentHealth <= 0)
        {
            Debug.Log("Me morí" + gameObject.name);
            ScoreManager.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }

    private void MoveTowardsBackpack()
    {
        var position = transform.position;
        Vector2 direction = player.transform.position - position;
        float randomFactor = Random.Range(0.8f, 1.2f);
        direction.Normalize();
        direction *= randomFactor;
        position += (Vector3)direction * (speed * Time.deltaTime);

        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(position, player.transform.position);

        // Si la distancia es menor o igual a la distancia de parada, detiene el movimiento
        if (distanceToPlayer <= stoppingDistance)
        {
            isTargetReached = true;
        }

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Backpack"))
        {
            Debug.Log("Detengo movimiento");
            isTargetReached = true;
        }
    }

    // Función para voltear el sprite si es necesario
    private void FlipSpriteIfNeeded()
    {
        if (transform.position.x > player.transform.position.x)
        {
            // Si el enemigo está en el lado positivo del eje X, voltear el sprite
            spriteRenderer.flipX = true;
        }
    }
}
