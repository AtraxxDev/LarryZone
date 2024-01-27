using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector3 target;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        
        velocity.Normalize();
        velocity *= speed;
        transform.position += velocity * Time.deltaTime;
    }

    public void ShootTowards(Vector3 target)
    {
        this.target = target;
        velocity = target - transform.position;
        transform.LookAt(target);
    }
}
