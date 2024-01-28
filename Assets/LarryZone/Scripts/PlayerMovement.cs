using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]private float currentSpeed;
    [SerializeField]private Animator animator;
    private void Start()
    {
        
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 playerInput = new Vector2();
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        Vector3 velocity = new Vector3(playerInput.x, playerInput.y, 0.0f) * currentSpeed;
        transform.position += velocity * Time.deltaTime;

        // Reproducir la animación correspondiente
        if (playerInput.magnitude > 0.1f)
        {
            // Si hay movimiento, reproducir la animación "walk"
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // Si no hay movimiento, reproducir la animación "idle"
            animator.SetBool("IsWalking", false);
        }

        
    }

    public void ApplySpeedBoost(float speedBoost, float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(speedBoost, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float speedBoost, float duration)
    {
        currentSpeed += speedBoost;
        yield return new WaitForSeconds(duration);
        currentSpeed -= speedBoost;
    }

}
