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
    private Renderer arm1Rend;
    private Renderer arm2Rend;
    private Color storedColor;

    public GameObject arm1;
    public GameObject arm2;

    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCounter(1);

        currentHealth = health; // sets the enemy health to the set health value
        rend = GetComponent<Renderer>();
        arm1Rend = arm1.GetComponent<Renderer>();
        arm2Rend = arm2.GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        if(currentHealth <= 0) // Checking for death
        {
            GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCounter(-1);
            Destroy(gameObject); // Destroys this enemy
            //GameObject.Find("Score").GetComponent<Score>().Point(); // Calls a function on the score script that adds 1 point to the score and displays it
        }

        if (flashCounter > 0) // this changes the colour of the enemy back to normal after the set amount of time
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
                arm1Rend.material.SetColor("_Color", storedColor);
                arm2Rend.material.SetColor("_Color", storedColor);

            }
        }
    }

    public void HurtEnemy() // this is called from the bullet script, after the bullet colides with the enemy.
    {
        currentHealth -= 1;
        flashCounter = flashLengh; // triggers a countdown to get the 
        rend.material.SetColor("_Color", Color.red); // this changes the colour of the enemy to red 
        arm1Rend.material.SetColor("_Color", Color.red);
        arm2Rend.material.SetColor("_Color", Color.red);
    }
}
