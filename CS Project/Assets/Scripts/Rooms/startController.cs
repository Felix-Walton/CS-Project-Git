using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startController : MonoBehaviour
{
    public static GameObject[] Rooms;

    private void Start()
    {
        Rooms = Resources.LoadAll<GameObject>("Rooms");

        Instantiate(Rooms[Random.Range(0, Rooms.Length)], (gameObject.transform.Find("New Room Locator").position), Quaternion.identity);

        Invoke("roomFinish", 1f);
    }

    public void roomFinish()
    {
        gameObject.transform.Find("Exit").GetComponent<doorManagment>().Open();
    }
}
