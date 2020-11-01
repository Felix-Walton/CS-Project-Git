using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunnerController : MonoBehaviour
{
    private Rigidbody myRB;
    public PlayerController thePlayer;

    public float waitTime;
    private float currentTime;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
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
        myRB.velocity = (transform.forward * 0.8f);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time) / frequency) / range) + height, transform.position.z);

        if (currentTime <= 1.3) // shooting state
        {
            bulletTimer += Time.deltaTime; // Makes only one bullet fire ever seccond
            if (bulletTimer >= 0.6)
            {
                Shoot();
                bulletTimer = 0;
            }
        }

        if (currentTime >= 5) // Resets the timers
        {
            currentTime = 0;
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
            bulletTimer = 0;
        }
    }

    public void Shoot() // Shooting function that creates the bullet prefab at the firepoint
    {
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
        BulletController newBullet2 = Instantiate(bullet, firePoint.position, firePoint2.rotation) as BulletController;
        BulletController newBullet3 = Instantiate(bullet, firePoint.position, firePoint3.rotation) as BulletController;

        newBullet.speed = bulletSpeed;
        newBullet2.speed = bulletSpeed;
        newBullet3.speed = bulletSpeed;
    }
}
