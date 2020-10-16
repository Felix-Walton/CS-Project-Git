using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController thePlayer;

    public float frequency;
    public float range;
    public float height;

    void Start()
    {
        myRB = GetComponent <Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z)); // point towards the player

        myRB.velocity = (transform.forward * moveSpeed); // move forwards

        transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / frequency) / range) + height, transform.position.z);

    }
}
