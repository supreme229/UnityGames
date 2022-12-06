using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private Dictionary<string, TextMeshProUGUI> gameObjects = new Dictionary<string, TextMeshProUGUI>();
    private void Awake()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in texts)
        {
            gameObjects[text.name] = text;
        }
        setGUIScore(0);
    }
    public void setGUIScore(int newScore)
    {
        try
        {
            gameObjects["ScoreValue"].text = newScore.ToString();
        }
        catch (KeyNotFoundException e)
        {
            Debug.Log(e.ToString());
        }
    }
    public void Update()
    {
        setGUIScore(GameManager.getScore());
        if (GameManager.getGameOn())
        {
            gameObjects["Start"].gameObject.SetActive(false);
            gameObjects["StartTut"].gameObject.SetActive(false);
        }
    }
}
