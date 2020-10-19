using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    private int enemyCount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void enemyCounter(int enemyChange)
    {
        enemyCount += enemyChange;
        Debug.Log(enemyCount);
    }
}
