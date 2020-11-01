using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text HighScore;

    void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }


    public void PlayGame() // Trigged when the play button is pressed, loads the game scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // Triggered when the quit game button is pressed, quits the game
    {
        Application.Quit();
        Debug.Log("quit");
    }
}   
// Todo add in high score display