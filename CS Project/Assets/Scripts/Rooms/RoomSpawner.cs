using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject getSpawnpoints;
    public GameObject particle;
    private GameObject newParticle;


    private Transform spawnPosition;

    public int enemyCounter;
    private float spawnTimer = 0;
    private float spawnTimerSet;


    private int roomsCleared;


    void Start()
    {
        enemyCounter = -1;
        Spawnpoints = new GameObject[getSpawnpoints.transform.childCount]; // These 3 lines put the game spawn points in an array
        for (int i = 0; i < getSpawnpoints.transform.childCount; i++)
        { Spawnpoints[i] = getSpawnpoints.transform.GetChild(i).gameObject; }
    }

    public void Startspawning()
    {
        roomsCleared = GameObject.Find("GameManager").GetComponent<GameManagment>().roomsClearedCount;
        enemyCounter = roomsCleared+1; // sets the enemy amount to spawn to room count


        spawnTimerSet = 1.5f - (roomsCleared / 10f);
        if (spawnTimerSet <= 0.6) { spawnTimerSet = 0.6f; } // decreases spawn timer based on score with a minimum of every 0.5 secconds 
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
                enemyCounter -= 1;
            }
        }
        else if (enemyCounter == 0)
        {
            if (GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCount == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManagment>().RoomCleared();
                gameObject.transform.Find("To Move").gameObject.transform.Find("Exit").GetComponent<doorManagment>().Open();
                GetComponent<RoomSpawner>().enabled = false;
            }
        }
    }

    public void SpawnEnemy() // Finds the spawn position and creates a particle effect
    {
        spawnPosition = Spawnpoints[Random.Range(0, Spawnpoints.Length)].transform;
        newParticle = Instantiate(particle, spawnPosition);
        Invoke("EnemyDelay", 1f);
    }

    private void EnemyDelay() // Updates the count at the correct time
    {
        //enemyCounter -= 1;
    }
}