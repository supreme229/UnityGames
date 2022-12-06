using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        Vector3 position = GetComponent<Renderer>().bounds.center;
        transform.RotateAround(position, Vector3.up, 45 * Time.deltaTime);
    }
}
