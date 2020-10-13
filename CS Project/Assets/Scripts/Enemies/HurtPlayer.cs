using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private float timing = 0f;

    public void OnTriggerStay(Collider other) // An update loop for when the enemy trigger box is touching something
    {
        if (other.gameObject.tag == "Player") // checks that the object that the enemy is touching is the player
        {
            if (timing > 0)
            {
                timing -= Time.deltaTime;
            }

            if (timing <= 0) // These two if statments are a timing feature that mean that the player is damaged every seccond it is touching the enemy
            {
                timing = 1;
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(); // Calls the function to damage the player
            }            
        }
    }

    private void OnTriggerExit() // When the enemy stops touching the player, timing is set to 0 so that it hurts the player next time instantly again
    {
        timing = 0f;
    }
}


