using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class doorManagment : MonoBehaviour
{
    private float targetPosition;
    private float startPosition;

    private void Start()
    {
        startPosition = transform.position.x;
        targetPosition = startPosition;
    }

    void FixedUpdate()
    {
        if (targetPosition < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
        }

        if (targetPosition > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
        }
    }

    public void Open() 
    { 
        targetPosition = startPosition - 8.5f; 
    }

    public void Close()
    {
        targetPosition = startPosition; 
    }
}
