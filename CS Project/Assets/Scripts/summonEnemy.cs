using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonEnemy : MonoBehaviour
{
    public ZombieController zombie;
    public ShooterControler shooter;
    private int random;

    void Start()
    {
        Invoke("EnemyDelay", 1f);
    }

    private void EnemyDelay() // The enemy is spawned 1 second after the particle effect apears.
    {
        random = Random.Range(1, 4); // chooses a random enemy
        if (random <= 2)    // chooses a random enemy to spawn
        {
            ZombieController newEnemy = Instantiate(zombie, transform.position, Quaternion.identity) as ZombieController;
        }
        else
        {
            ShooterControler newEnemy = Instantiate(shooter, transform.position, Quaternion.identity) as ShooterControler;
        }
        Destroy(gameObject); // deletes the particle effect
    }
}
