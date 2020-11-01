using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerController : MonoBehaviour
{
    private Rigidbody myRB;
    private PlayerController thePlayer;

    public float waitTime;
    private float currentTime;
    public Transform firePoint;
    public BulletController bullet;

    public float frequency;
    public float range;
    public float height;


    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
        currentTime = 0.5f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime <= 1 & currentTime > 0) // still state
        {
            transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
        }
        if (currentTime <= 3 & currentTime > 1) // Moving back state
        {
            transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
            transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / frequency) / range * 2) + height, transform.position.z);
            myRB.velocity = (transform.forward * -1);
        }
        if (currentTime <= 4 & currentTime > 3) // Dashes forward
        {
            transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / (frequency/ 2)) / range) + height, transform.position.z);
            myRB.velocity = (transform.forward * 13);
        }
        if (currentTime >= 4) // Resets the timers
        {
            currentTime = 0.5f;
        }
    }
}
