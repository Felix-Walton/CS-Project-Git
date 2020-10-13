using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health = 3;
    private int currentHealth;

    public float flashLengh;
    private float flashCounter;

    private Renderer rend; // componant used to change the enemy’s colour
    private Color storedColor;

    void Start()
    {
        currentHealth = health; // sets the enemy health to the set health value
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        if(currentHealth <= 0) // Checking for death
        {
            Destroy(gameObject); // Destroys this enemy
            GameObject.Find("Score").GetComponent<Score>().Point(); // Calls a function on the score script that adds 1 point to the score and displays it
        }

        if (flashCounter > 0) // this changes the colour of the enemy back to normal after the set amount of time
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtEnemy() // this is called from the bullet script, after the bullet colides with the enemy.
    {
        currentHealth -= 1;
        flashCounter = flashLengh; // triggers a countdown to get the 
        rend.material.SetColor("_Color", Color.red); // this changes the colour of the enemy to red 
    }
}
