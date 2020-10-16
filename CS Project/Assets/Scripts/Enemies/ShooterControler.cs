using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShooterControler : MonoBehaviour
{
    private Rigidbody myRB;
    public PlayerController thePlayer;

    public float waitTime;
    private float currentTime;
    private bool shot;
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

    void Update()
    {
        transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));
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
            transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time)/frequency)/range) +height, transform.position.z);
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

    public void Shoot() // Shooting function that creates the bullet prefab at the firepoint
    {
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController; 
        newBullet.speed = bulletSpeed;
    }
}