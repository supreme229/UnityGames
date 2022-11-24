using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstancer : MonoBehaviour
{
    public float timer = 0f;
    public float frequency = 2f;
    public GameObject obstacle;
    public GameObject coin;
    public GameObject player;
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f && !GameVariables.gameIsOver())
        {
            float height = Random.Range(-5f, 5f);
            transform.position = new Vector3(15f, height, 0f);
            Instantiate(obstacle, transform.position, transform.rotation);
           
            if(Random.value > 0.5f)
            {
                Vector3 coinPosition = new Vector3(transform.position.x, height + Random.Range(2.5f, 6.7f), transform.position.z);
                Instantiate(coin, coinPosition, transform.rotation);
            }

            timer = frequency;
        }

    }
}