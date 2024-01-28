using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector3 target;
    Vector3 direction;
    public float damage;
    public float rateOfFire;
    private bool shooting;
    public Transform sprite_;


    // Update is called once per frame
    void Update()
    {
        if (shooting) { 
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void ShootTowards(Vector3 target)
    {
        transform.parent = null;
        this.target = target;
        direction = this.target - transform.position;
        direction.Normalize();
        shooting = true;
        if (sprite_ != null)
        {
            sprite_.up = direction;
        }
        
    }
}
