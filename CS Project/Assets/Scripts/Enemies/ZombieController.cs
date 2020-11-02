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
        rotate();

        myRB.velocity = (transform.forward * moveSpeed); // move forwards

        myRB.MovePosition(new Vector3(transform.position.x, (Mathf.Sin((Time.time) / frequency) / range) + height, transform.position.z));
    }

    void rotate()
    {
        var qTo = Quaternion.LookRotation(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z) - transform.position);
        qTo = Quaternion.Slerp(transform.rotation, qTo, 100f * Time.deltaTime);
        myRB.MoveRotation(qTo);
    }
}
