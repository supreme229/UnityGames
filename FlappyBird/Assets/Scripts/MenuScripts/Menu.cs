using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
