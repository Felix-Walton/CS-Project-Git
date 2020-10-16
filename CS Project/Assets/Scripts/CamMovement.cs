using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform point;

    void Update()     // moves the Camera to always be the same position relative to the player
    {
        GameObject.Find("Main Camera").transform.position = new Vector3 (point.position.x, 11, point.position.z - 10); 
    }
}
