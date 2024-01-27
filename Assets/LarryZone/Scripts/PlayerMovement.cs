using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]private float currentSpeed;
    public GameObject bulletPrefab;

    private float shootingDelay = 1f;
    private float timePassed = 0f;


    private void Start()
    {
        currentSpeed = speed;
        timePassed = shootingDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime; 
        //Shooting
        if (Input.GetMouseButton(0) && timePassed >= shootingDelay)
        {
            BulletMovement instance;
            Vector3 shootingTarget = new Vector3();
            shootingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootingTarget.z = transform.position.z;
            instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<BulletMovement>();
            if(instance != null)
            {
                instance.ShootTowards(shootingTarget);
            }
            timePassed = 0f;
        }

        //Movement
        Vector2 playerInput = new Vector2();
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        Vector3 velocity = new Vector3(playerInput.x, playerInput.y, 0.0f) * currentSpeed;
        transform.position += velocity * Time.deltaTime;
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