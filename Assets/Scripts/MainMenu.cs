using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1f;
        Saving.startTime = Time.time;
        PauseMenu.inMainMenu = false;
        Saving.SaveState();
        SceneManager.LoadScene("Game");
        Saving.LoadState();
        PauseMenu.isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
