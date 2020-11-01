using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagment : MonoBehaviour
{
    public int enemyCount;
    public Text scoreText;
    private int enemyKillCount;
    public int roomsClearedCount;

    public bool roomJustCleared = true;

    void Start()
    {
        roomJustCleared = true;
    }


    public void EnenmyKill() //This function is called from an enemy when they die 
    {
        enemyKillCount += 1;
        //scoreText.text = enemyKillCount.ToString("0"); //This displays the kill count to the overlay
    }

    public void RoomCleared() 
    {
        roomsClearedCount += 1;
        scoreText.text = roomsClearedCount.ToString("0"); //This displays the room count to the overlay
        roomJustCleared = true;
    }

    public void enemyCounter(int enemyChange)
    {
        enemyCount += enemyChange;
    }
}
