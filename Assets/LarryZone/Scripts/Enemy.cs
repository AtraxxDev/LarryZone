using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int damage = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsBackpack();
    }
    private void MoveTowardsBackpack()
    { 
       var position = transform.position; 
       Vector2 direction = player.transform.position - position;
       float randomFactor = Random.Range(0.8f, 1.2f);
       direction.Normalize();
       direction *= randomFactor;
       position += (Vector3)direction * (speed * Time.deltaTime);
       transform.position = position;
    }
}
