using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform bridge;
    public static GameObject[] Rooms;

    private int targetHeight;

    private Transform toMove;


    private void Start()
    {
        Rooms = Resources.LoadAll<GameObject>("Rooms");

        targetHeight = 29;

        toMove = gameObject.transform.Find("To Move");
        Instantiate(bridge, toMove.transform.Find("Bridge Locator"));

        toMove.transform.position = new Vector3 (toMove.transform.position.x, 29, toMove.transform.position.z);
    }

    private void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagment>().roomJustCleared == true)
        {

            if (toMove.transform.position.y == 29)
            {
                GameObject.Find("GameManager").GetComponent<GameManagment>().roomJustCleared = false;
                targetHeight = -1;
                Invoke("openEntrance", 2.5f);
            }
        }
    }

    void FixedUpdate()
    {
        if (toMove.transform.position.y > targetHeight)
       { toMove.transform.position = new Vector3(toMove.transform.position.x, toMove.transform.position.y - 0.25f, toMove.transform.position.z); }
    }

    private void openEntrance()
    {
        toMove.transform.Find("Entrance").GetComponent<doorManagment>().Open();
        Instantiate(Rooms[Random.Range(0, Rooms.Length)], (toMove.transform.Find("New Room Locator").position), Quaternion.identity);
    }
}