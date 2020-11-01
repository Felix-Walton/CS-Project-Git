using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pauseMenu : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathScreen;
    public AudioMixer audioMixer;
    private float currentVolume;
    public Slider slider;
    public Text finalScoreDisplay;

    private int finalScore;

    void Start()
    {
        bool resut = audioMixer.GetFloat("Volume", out currentVolume);
        slider.value = currentVolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true); // activates the menu
        Time.timeScale = 0f; // Pauses the game
        GameIsPaused = true;
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false); // deactivates the menu
        Time.timeScale = 1f; // Unpauses the game
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void death()
    {
        deathScreen.SetActive(true); // activates death screen
        Time.timeScale = 0f; // Pauses the game
        GameIsPaused = true;

        finalScore = int.Parse(GameObject.Find("GameManager").GetComponent<GameManagment>().scoreText.text);

        finalScoreDisplay.text = finalScore.ToString(); // displays the final score

        if (finalScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", finalScore); // saves the new high score, if it is higher
        }
    }
}
