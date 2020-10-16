using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour //This system will almost definatly be redone
{
    public float spawnTime;

    public Vector3 position;
    public ZombieController enemy;
    public ShooterControler shooter;
    private float spawnCount;
    private int random;

    void Start()
    {
        spawnCount = 1;
    }

    void Update()
    {
        if (spawnCount > 0)
        {
            spawnCount -= Time.deltaTime;
            if (spawnCount <= 0)
            {
                position = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20)); // Spawns the enemies at a random position
                random = Random.Range(1, 4);
                if (random <= 2)    // chooses a random enemy to spawn, currently bias towards zombies over shooters
                {
                    ZombieController newEnemy = Instantiate(enemy, position, Quaternion.identity) as ZombieController;
                }
                else
                {
                    ShooterControler newEnemy = Instantiate(shooter, position, Quaternion.identity) as ShooterControler;
                }
                spawnCount = spawnTime;
                if (spawnTime > 2) // These speed up the spawning to make the game harder
                {
                    spawnTime -= 0.2f;
                }
                else if (spawnTime > 1)
                {
                    spawnTime -= 0.1f;
                }
            }
        }
    }
}
