using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private static bool gameOn = false;
    private static int score = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public static int getScore()
    {
        return score;
    }
    public static void updateScore(int incr)
    {
        score += incr;
    }
    public static void resetScore()
    {
        score = 0;
    }
    public static bool getGameOn()
    {
        return gameOn;
    }
    public static void setGameOn(bool newGameOn)
    {
        gameOn = newGameOn;
    }
}
