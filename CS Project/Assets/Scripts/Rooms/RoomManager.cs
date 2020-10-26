using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public Transform bridge;
    public static GameObject[] Rooms;

    public int targetHeight = -1;

    private void Start()
    {
        Instantiate(bridge, gameObject.transform.Find("Bridge Locator"));

        Rooms = Resources.LoadAll<GameObject>("Rooms");

        transform.position = new Vector3 (transform.position.x, transform.position.y - 62, transform.position.z);

        Invoke("openEntrance", 3f);
    }

    void FixedUpdate()
    {
       if (transform.position.y < targetHeight)
        { transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); }

       if (transform.position.y > targetHeight)
       { transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z); }
    }

    private void openEntrance()
    {
        gameObject.transform.Find("Entrance").GetComponent<doorManagment>().Open();
    }


    public void roomFinish()
    {
        gameObject.transform.Find("Exit").GetComponent<doorManagment>().Open();

        Instantiate(Rooms[Random.Range(0, Rooms.Length)], (gameObject.transform.Find("New Room Locator").position), Quaternion.identity);
    }
}