using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBobbing : MonoBehaviour
{
    // Start is called before the first frame update


    public float frequency;
    public float range;
    public float height;

    void Update()
    {
        transform.position =   new Vector3(transform.position.x, (Mathf.Sin((Time.time) / (frequency / 2)) / range * 2) + height, transform.position.z);
    }
}
