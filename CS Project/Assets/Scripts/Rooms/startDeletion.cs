using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDeletion : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.parent.gameObject.transform.parent.GetComponent<startController>().targetHeight = -63;
        }
    }
}
