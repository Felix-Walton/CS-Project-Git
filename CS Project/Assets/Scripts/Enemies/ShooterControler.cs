using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShooterControler : MonoBehaviour
{
    private Rigidbody myRB;
    public PlayerController thePlayer;

    public float waitTime;
    private float currentTime;
    public Transform firePoint;
    public BulletController bullet;
    public float bulletSpeed;
    private float bulletTimer;

    public float frequency;
    public float range;
    public float height;


    void Start()
    {
       myRB = GetComponent<Rigidbody>();
       thePlayer = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        rotate();
        currentTime += Time.deltaTime;

        if (currentTime >= 8) // Resets the timers
        {
            currentTime = 0;
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
            bulletTimer = 0;
        }

        if (currentTime <= 8 & currentTime > 5) // Moving state
        {
            myRB.velocity = (transform.forward * 4);
            myRB.MovePosition(transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / (frequency)) / range) + height, transform.position.z));
        }

        if (currentTime <= 5) // shooting state
        {
            bulletTimer += Time.deltaTime; // Makes only one bullet fire ever seccond
            if (bulletTimer >= 1)
            {
                Shoot();
                bulletTimer = 0;
            }
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
        }
    }

    void rotate()
    {
        var qTo = Quaternion.LookRotation(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z) - transform.position);
        qTo = Quaternion.Slerp(transform.rotation, qTo, 100f * Time.deltaTime);
        myRB.MoveRotation(qTo);
    }

    public void Shoot() // Shooting function that creates the bullet prefab at the firepoint
    {
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController; 
        newBullet.speed = bulletSpeed;
    }
}