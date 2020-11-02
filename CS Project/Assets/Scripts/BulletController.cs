using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    public Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, 5); // destroys the game object after 5 seconds
        rb.AddForce(transform.forward * speed * 100); // Moves the bullet forward
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // If colided with enemy, hurts the enemy and then deletes  
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(); // Calls the hurt enemy function
        }
        else if (collision.gameObject.tag == "Player") // If colided with player, hurts the player and then deletes  
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(); // Calls the hurt enemy function
        }
        else
        {
            Destroy(gameObject);
        }
    }
}