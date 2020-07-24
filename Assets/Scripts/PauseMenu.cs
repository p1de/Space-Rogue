using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool inMainMenu = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !UpgradeMenu.isUpgrading)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Click");
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Click");
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        inMainMenu = true;
        isPaused = true;
        Saving.SaveState();
        SceneManager.LoadScene("MainMenu");
        Saving.LoadState();
        Saving.savedOnce = true;
        Saving.saved = false;
    }
    public void HardReset()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Saving.RebootState();
    }
}
