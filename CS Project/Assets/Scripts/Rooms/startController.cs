using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startController : MonoBehaviour
{
    public static GameObject[] Rooms;

    public int targetHeight;

    private void Start()
    {
        Rooms = Resources.LoadAll<GameObject>("Rooms");
        Invoke("roomFinish", 1f);
    }

    void FixedUpdate()
    {
        if (transform.position.y > targetHeight)
        { transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z); }

        if (transform.position.y == -63)
        { Destroy(gameObject); }
    }

    public void roomFinish()
    {
        gameObject.transform.Find("Exit").GetComponent<doorManagment>().Open();

        Instantiate(Rooms[Random.Range(0, Rooms.Length)], (gameObject.transform.Find("New Room Locator").position), Quaternion.identity);
    }
}
