using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{ 
    private float edge;
    private void Start()
    {
        edge = (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, Camera.main.nearClipPlane))).x;
    }
    private void Update()
    {
        if (!GameVariables.gameIsOver())
        {
            if (transform.position.x < edge - 4f)
            {
                Destroy(gameObject);
            }
            transform.Translate(-5f * Time.deltaTime, 0, 0, Space.World);
        }
        Vector3 position = GetComponent<Renderer>().bounds.center;
        transform.RotateAround(position, Vector3.up, 45 * Time.deltaTime);
    }
}
