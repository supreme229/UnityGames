using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    private static GameVariables _instance;
    public static GameVariables Instance { get { return _instance; } }

    private static int score = 0;
    private static bool isGameover = false;
    private static bool gameOn = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
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
    public static bool gameIsOver()
    {
        return isGameover;
    }
    public static void updateGameover(bool value)
    {
        isGameover = value;
    }
    public static bool getGameOn()
    {
        return gameOn;
    }
    public static void setGameOn(bool value)
    {
        gameOn = value;
    }
}
