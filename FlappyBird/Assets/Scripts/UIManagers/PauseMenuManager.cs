using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject gamePausedUI;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameVariables.getGameOn())
        {
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

    private void Pause()
    {
        Time.timeScale = 0f;
        gamePausedUI.SetActive(true);
        isPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        gamePausedUI.SetActive(false);
        isPaused = false;
    }

    public void Menu()
    {
        gamePausedUI.SetActive(false);
        FindObjectOfType<SceneLoader>().LoadConcreteScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
