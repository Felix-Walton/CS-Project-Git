using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonEnemy : MonoBehaviour
{
    public ZombieController zombie;
    public ShooterControler shooter;
    public runnerController runner;
    public shotgunnerController shotgunner;

    private int random;

    void Start()
    {
        Invoke("EnemyDelay", 1f);
        GameObject.Find("GameManager").GetComponent<GameManagment>().enemyCounter(1);
    }

    private void EnemyDelay() // The enemy is spawned 1 second after the particle effect apears.
    {
        random = Random.Range(1, 6); // chooses a random enemy
        if (random <= 2)    // chooses the enemy to spawn
        {
            ZombieController newEnemy = Instantiate(zombie, transform.position, Quaternion.identity) as ZombieController;
        }
        else if (random == 3)
        {
            ShooterControler newEnemy = Instantiate(shooter, transform.position, Quaternion.identity) as ShooterControler;
        }
        else if (random == 4)
        {
            runnerController newEnemy = Instantiate(runner, transform.position, Quaternion.identity) as runnerController;
        }
        else if (random == 5)
        {
            shotgunnerController newEnemy = Instantiate(shotgunner, transform.position, Quaternion.identity) as shotgunnerController;
        }

        Destroy(gameObject); // deletes the particle effect
    }
}