using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShooterControler : MonoBehaviour
{
    private Rigidbody myRB;
    private PlayerController thePlayer;

    public float waitTime;
    private float currentTime;
    private bool shot;
    public Transform firePoint;
    public BulletController bullet;
    public float bulletSpeed;
    private float bulletTimer;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
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
        }

        if (currentTime <= 5) // shooting state
        {
            bulletTimer += Time.deltaTime; // Makes only one bullet fire ever seccond
            if (bulletTimer >= 1)
            {
                Shoot();
                bulletTimer = 0;
            }
        }
    }

    public void Shoot() // Shooting function that creates the bullet prefab at the firepoint
    {
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController; 
        newBullet.speed = bulletSpeed;
    }
}