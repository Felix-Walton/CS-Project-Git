using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDetection : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.parent.gameObject.transform.parent.GetComponent<RoomSpawner>().Startspawning();
            gameObject.transform.parent.gameObject.transform.Find("Entrance").GetComponent<doorManagment>().Close();
            gameObject.SetActive(false);
        }
    }
}
