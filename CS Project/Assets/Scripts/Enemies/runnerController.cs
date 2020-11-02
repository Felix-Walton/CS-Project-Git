using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerController : MonoBehaviour
{
    private Rigidbody myRB;
    private PlayerController thePlayer;

    public float waitTime;
    private float currentTime;

    public float frequency;
    public float range;
    public float height;


    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        rotate();      
        currentTime = 1f;
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime <= 1 & currentTime > 0) // still state
        {
            rotate();
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
        }
        if (currentTime <= 2 & currentTime > 1) // Moving back state
        {
            rotate();
            myRB.MovePosition(transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / (frequency)) / range) + height, transform.position.z));
            myRB.velocity = (transform.forward * -1);
        }
        if (currentTime <= 3 & currentTime > 2) // Dashes forward
        {
            myRB.MovePosition(new Vector3(transform.position.x, (Mathf.Sin((Time.time) / (frequency / 2)) / range * 2) + height, transform.position.z));
            myRB.velocity = (transform.forward * 15);
        }
        if (currentTime >= 3) // Resets the timers
        {
            currentTime = 0.5f;
        }
    }

    void rotate()
    {
        var qTo = Quaternion.LookRotation(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z) - transform.position);
        qTo = Quaternion.Slerp(transform.rotation, qTo, 100f * Time.deltaTime);
        myRB.MoveRotation(qTo);
    }
}
