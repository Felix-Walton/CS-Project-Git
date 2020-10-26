using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startController : MonoBehaviour
{
    public Transform bridge;
    public static GameObject[] Rooms;

    public int targetHeight;

    private void Start()
    {
        Instantiate(bridge, gameObject.transform.Find("Bridge Locator"));
        Rooms = Resources.LoadAll<GameObject>("Rooms");
        Invoke("roomFinish", 1f);
    }

    void FIxedUpdate()
    {
        if (transform.position.y > targetHeight)
        { transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z); }
    }

    public void roomFinish()
    {
        gameObject.transform.Find("Exit").GetComponent<doorManagment>().Open();

        Instantiate(Rooms[Random.Range(0, Rooms.Length)], (gameObject.transform.Find("New Room Locator").position), Quaternion.identity);
    }
}
