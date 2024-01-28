using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    public Enemy enemy;
    public GameObject initialTarget;
    public GameObject currentTarget;

    private void Start()
    {
        initialTarget = enemy.player;
        currentTarget = enemy.player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            Debug.Log("Colisione con el player");
            currentTarget = collision.gameObject;
            enemy.player = currentTarget;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            Debug.Log("Sali del player");

            currentTarget = initialTarget;
            enemy.player = currentTarget;
        }
    }
}
