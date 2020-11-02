using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public GameObject healthDisplay;

    private bool invulnerable = false;
    private float vulnerableTime = 1;

    public GameObject damageParticles;
    public GameObject deathParticles;

    void Start()
    {
        currentHealth = startingHealth; // Sets the health value
    }

    void Update()
    {
        if(currentHealth <= 0) // Checking for death
        {
            Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Invoke("Death", 0.5f); // Loads the scene again after 2 secconds
        }

        if (invulnerable == true) // makes player invunrible for 3 secconds
        {
            vulnerableTime -= Time.deltaTime;
            if(vulnerableTime<= 0)
            {
                invulnerable = false;
                vulnerableTime = 1;
            }
        }
    }
    
    public void HurtPlayer() // Function that gets called when to damage the player
    {
        if (invulnerable == false)
        {
            Instantiate(damageParticles, gameObject.transform.position, Quaternion.identity);
            invulnerable = true;
            currentHealth -= 1;
            healthDisplay.gameObject.GetComponent<Hearts>().Damage();
        }
    }

    void Death()
    {
        GameObject.Find("Pause canvas").GetComponent<pauseMenu>().death();
    }
}



