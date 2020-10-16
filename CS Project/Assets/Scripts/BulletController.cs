using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private bool used;
    public Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, 5); // destroys the game object after 5 seconds
        used = false;
        rb.AddForce(transform.forward * speed *100);
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime); // Moves the bullet forward
    }

    void OnCollisionExit(Collision x)
    {
        Destroy(gameObject);
        Debug.Log("leave");
    }

    void OnCollisionStay(Collision x)
    {
        Debug.Log("in");
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (used == false)
        {
            used = true;
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
}