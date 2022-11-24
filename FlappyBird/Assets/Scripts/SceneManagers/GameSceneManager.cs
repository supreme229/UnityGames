using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Awake()
    {
        GameVariables.setGameOn(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameVariables.setGameOn(true);
            Time.timeScale = 1f;
            text.gameObject.SetActive(false);
        }
    }
}
