using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform point;
    public int height = 13;
    public int distance = 10;

    void Update()     // moves the Camera to always be the same position relative to the player
    {
        GameObject.Find("Main Camera").transform.position = new Vector3 (point.position.x, height, point.position.z - distance); 
    }
}
