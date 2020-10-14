using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private bool used;

    void Start()
    {
        // Destroy(gameObject, 5); // destroys the game object after 5 seconds
        used = false;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Moves the bullet forward
    }

    void OnCollisionEnter(Collision other)
    {
        if (used == false)
        {
            used = true;
            if (other.gameObject.tag == "Enemy") // If colided with enemy, hurts the enemy and then deletes  
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(); // Calls the hurt enemy function
            }
            else if (other.gameObject.tag == "Player") // If colided with player, hurts the player and then deletes  
            {
                Debug.Log("hit");
                Destroy(gameObject);
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(); // Calls the hurt enemy function

            }
        }
    }
}