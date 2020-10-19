using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject getSpawnpoints;
   

    public ZombieController enemy;
    public ShooterControler shooter;

    private Vector3 spawnPosition;
    private int random;

    public bool spawning;
    private float spawnTimer = 3;

    void Start()
    {
        Spawnpoints = new GameObject[getSpawnpoints.transform.childCount];
        for (int i = 0; i < getSpawnpoints.transform.childCount; i++)
        {
            Spawnpoints[i] = getSpawnpoints.transform.GetChild(i).gameObject;
        }
        spawning = true;
    }

    void Update()
    {

        if (spawning == true)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnEnemy();
                spawnTimer = 3;
            }
        } 
    }

    public void SpawnEnemy()
    {
        spawnPosition = Spawnpoints[Random.Range(0, Spawnpoints.Length)].transform.position;
        
        random = Random.Range(1, 4);
        if (random <= 2)    // chooses a random enemy to spawn, currently bias towards zombies over shooters
        {
            ZombieController newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity) as ZombieController;
        }
        else
        {
            ShooterControler newEnemy = Instantiate(shooter, spawnPosition, Quaternion.identity) as ShooterControler;
        }
        

    }

}
