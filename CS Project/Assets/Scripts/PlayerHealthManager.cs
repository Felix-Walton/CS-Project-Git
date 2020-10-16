using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    private Renderer rend;
    private Color storedColor;
    public GameObject healthDisplay;

    private bool invulnerable = false;
    private float vulnerableTime = 1;

    void Start()
    {
        currentHealth = startingHealth; // Sets the health value
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        if(currentHealth <= 0) // Checking for death
        {
            gameObject.SetActive(false); // Deletes the player TTODO something other than deleting the player
            Invoke("LoadMenu", 2f); // Loads the scene again after 2 secconds
        }

        if (invulnerable == true) // makes player invunrible for 3 secconds
        {
            vulnerableTime -= Time.deltaTime;
            if(vulnerableTime<= 0)
            {
                rend.material.SetColor("_Color", storedColor);
                invulnerable = false;
                vulnerableTime = 1;
            }
        }
    }
    
    public void HurtPlayer() // Function that gets called when to damage the player
    {
        if (invulnerable == false)
        {
            rend.material.SetColor("_Color", Color.red);
            invulnerable = true;
            currentHealth -= 1;
            healthDisplay.gameObject.GetComponent<Hearts>().Damage();
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0); // Loads scene again
    }
}



