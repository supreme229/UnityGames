using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameManager.resetScore();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
