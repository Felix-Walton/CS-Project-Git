﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomDeletion : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
