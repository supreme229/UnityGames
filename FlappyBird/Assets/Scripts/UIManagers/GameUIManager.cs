using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    private Dictionary<string, TextMeshProUGUI> gameObjects = new Dictionary<string, TextMeshProUGUI>();
    private void Awake()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
        foreach(TextMeshProUGUI text in texts)
        {
            gameObjects[text.name] = text;
        }
        setGUIScore(0);
    }
    public void setGUIScore(int newScore)
    {
        try
        {
            gameObjects["score-gui"].text = newScore.ToString();
        }
        catch (KeyNotFoundException e)
        {
            Debug.Log(e.ToString());
        }
    }
}
