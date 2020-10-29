using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject getSpawnpoints;
    public GameObject particle;
    private GameObject newParticle;


    private Vector3 spawnPosition;

    private int enemyCounter = -1;
    private float spawnTimer = 0;
    private float spawnTimerSet;



    void Start()
    {
        Spawnpoints = new GameObject[getSpawnpoints.transform.childCount]; // These 3 lines put the game spawn points in an array
        for (int i = 0; i < getSpawnpoints.transform.childCount; i++)
        { Spawnpoints[i] = getSpawnpoints.transform.GetChild(i).gameObject; }
    }

    public void Startspawning()
    {
        enemyCounter = 5;    // These two perametes control the amount of enemies, and the time between spawning
        spawnTimerSet = 1.5f; // They will be changed to scale depending on the score
    }

    void Update()
    {
        if (enemyCounter > 0) // Cheacks if the spawning process is still active
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnEnemy(); // The spawning function
                spawnTimer = spawnTimerSet; // resets the timer
            }
        }
        else if (enemyCounter == 0)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCount == 0)
            {
                GetComponent<RoomManager>().roomFinish();
                GetComponent<RoomSpawner>().enabled = false;
            }
        }
    }

    public void SpawnEnemy() // Finds the spawn position and creates a particle effect
    {
        spawnPosition = Spawnpoints[Random.Range(0, Spawnpoints.Length)].transform.position;
        newParticle = Instantiate(particle, new Vector3 (spawnPosition.x, 0.05f , spawnPosition.z), Quaternion.Euler(-90,0,0));
        Invoke("EnemyDelay", 1f);
    }

    private void EnemyDelay() // Updates the count at the correct time
    {
        enemyCounter -= 1;
    }
}