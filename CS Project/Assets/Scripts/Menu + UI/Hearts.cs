using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    private int health = 5;

    public void Damage()
    {
        if (health == 5)
        {
            heart1.SetActive(false);
        }
        if (health == 4)
        {
            heart2.SetActive(false);
        }
        if (health == 3)
        {
            heart3.SetActive(false);
        }
        if (health == 2)
        {
            heart4.SetActive(false);
        }
        if (health == 1)
        {
            heart5.SetActive(false);
        }
        health -= 1;
    }
}
