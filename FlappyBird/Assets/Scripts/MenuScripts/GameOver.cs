using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public void Start()
    {
        finalScore.text = GameVariables.getScore().ToString();
    }
    public void PlayGame()
    {
        GameVariables.updateGameover(false);
        GameVariables.resetScore();
        FindObjectOfType<SceneLoader>().LoadConcreteScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
