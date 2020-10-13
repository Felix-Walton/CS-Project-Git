using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController thePlayer;

    void Start()
    {
        myRB = GetComponent <Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(thePlayer.transform.position); // point towards the player

        myRB.velocity = (transform.forward * moveSpeed); // move forwards
    }
}
