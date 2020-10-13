using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public float flashLengh;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public GameObject healthDisplay;

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

        if (flashCounter > 0) // This changes the colour of the enemy back to normal after the set amount of time
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer() // Function that gets called when to damage the player
    {
        currentHealth -=1;
        flashCounter = flashLengh;  // Starts a contdown to change the colour back
        rend.material.SetColor("_Color", Color.red);
        healthDisplay.gameObject.GetComponent<Hearts>().Damage();
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0); // Loads scene again
    }
}



