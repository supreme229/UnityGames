using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstancer : MonoBehaviour
{
    public float timer = 0f;
    public float frequency = 9f;
    public GameObject ground;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Instantiate(ground, new Vector3(0, 0, 0), transform.rotation);
            timer = frequency;
        }
    }
}