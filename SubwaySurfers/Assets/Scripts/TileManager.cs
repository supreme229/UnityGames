using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    private List<GameObject> activeTiles = new();
    private GameObject player;
    private float tileSize = 60f;
    private int idx = 0;
    private int tilesDeleteIndexer = 1;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tilesCreator(0);
        for(int i = 0; i < 19; i++)
        {
            tilesCreator();
        }
    }

    void Update()
    {
        if(player.transform.position.z > 65f + activeTiles[0].transform.position.z)
        {
            tilesDeleter();
            tilesCreator();
        }
    }

    private void tilesCreator(int optIdx = -1)
    {
        Vector3 tilePosition = new Vector3(-0.8f, 0f, idx * tileSize);
        GameObject obj; 
        if (optIdx == -1) 
        { 
            obj = Instantiate(tiles[Random.Range(0, tiles.Length)], tilePosition, transform.rotation);
        }
        else
        {
            obj = Instantiate(tiles[optIdx], tilePosition, transform.rotation);
        }
        activeTiles.Add(obj);
        idx++;
    }

    private void tilesDeleter()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        tilesDeleteIndexer++;
    }
}
