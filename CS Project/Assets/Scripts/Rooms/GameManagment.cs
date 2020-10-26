using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public int enemyCount;
    public bool roomFinished = false;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void enemyCounter(int enemyChange)
    {
        enemyCount += enemyChange;
    }
}
