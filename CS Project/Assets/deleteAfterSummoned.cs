using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfterSummoned : MonoBehaviour
{
    void Start()
    {
        Invoke("Delay", 1f);
    }

    private void Delay() // Delets object after 1 seccond
    {
        Destroy(gameObject); 
    }
}
