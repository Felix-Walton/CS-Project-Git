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
    private Renderer bodyPart1;
    private Renderer bodyPart2;
    private Color storedColor1;
    private Color storedColor2;


    public GameObject bodyPart1_;
    public GameObject bodyPart2_;

    public GameObject deathParticles;


    void Start()
    {
        //GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCounter(1);

        currentHealth = health; // sets the enemy health to the set health value
        bodyPart1 = bodyPart1_.GetComponent<Renderer>();
        bodyPart2 = bodyPart2_.GetComponent<Renderer>();
        storedColor1 = bodyPart1.material.GetColor("_Color");
        storedColor2 = bodyPart2.material.GetColor("_Color");

    }

    void Update()
    {
        if(currentHealth <= 0) // Checking for death
        {
            GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCounter(-1);
            GameObject.Find("GameManager").GetComponent<GameManagment>().EnenmyKill(); // Calls a function on the score script that adds 1 point to the score

            Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject); // Destroys this enemy

        }

        if (flashCounter > 0) // this changes the colour of the head back to normal after the set amount of time
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                bodyPart1.materials[0].SetColor("_Color", storedColor1);
                bodyPart1.materials[1].SetColor("_Color", storedColor1);
                bodyPart2.material.SetColor("_Color", storedColor2);


            }
        }
    }

    public void HurtEnemy() // this is called from the bullet script, after the bullet colides with the enemy.
    {
        Debug.Log("hurt");
        currentHealth -= 1;
        flashCounter = flashLengh; // triggers a countdown to get the 
        bodyPart1.materials[0].SetColor("_Color", Color.red); // this changes the colour of the head to red
        bodyPart1.materials[1].SetColor("_Color", Color.red);
        bodyPart2.material.SetColor("_Color", Color.red);
    }
}
