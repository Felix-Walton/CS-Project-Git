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
    public AudioMixer audioMixer;
    private float currentVolume;
    public Slider slider;

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
        pauseMenuUI.SetActive(true); // deactivates the menu
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
}
