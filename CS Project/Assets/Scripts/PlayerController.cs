using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public GameObject pauseCanvas;

    public float frequency;
    public float range;
    private float distanceFromFloor;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        distanceFromFloor = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseCanvas.GetComponent<pauseMenu>().GameIsPaused) // Only allows movement and shooting when the game is paused 
        {
            Movement(); // The movement function  
            Shooting(); //The shooting function
            transform.position = new Vector3(transform.position.x, (Mathf.Sin((Time.time)/frequency)/range)+distanceFromFloor, transform.position.z);
        }
    }


    private void Shooting()
    {

        if (Input.GetMouseButtonDown(0)) // This varibale is detected by shooting script
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }

    private void Movement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Gets the Vector  of Input, which by default is WASD (need to change for customisable controls) 
        moveVelocity = moveInput * moveSpeed; // Sets the moveVelocity variable of the player to the defined vector

        Ray camraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);            // This draws a raycast from the camera, following the mouse position.
        float rayLength;

        if (groundPlane.Raycast(camraRay, out rayLength))
        {
            Vector3 pointToLook = camraRay.GetPoint(rayLength);
            Debug.DrawLine(camraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z)); // The player points where the raycast intersect the ground plane
        }
    }

    private void FixedUpdate() 
    {
        myRigidbody.velocity = moveVelocity;
    }
}