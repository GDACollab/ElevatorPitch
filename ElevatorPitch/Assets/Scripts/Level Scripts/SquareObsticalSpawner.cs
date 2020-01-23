using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareObsticalSpawner : MonoBehaviour
{
    public GameObject SquareObstaclePrefab;
    public Transform[] spawnLocations;
    public GameObject whatToSpawnPrefab;
    public GameObject whatToSpawnClone;

    public void spawnObstacles()
    {
        for(int i = 0; i < spawnLocations.Length; i++)
        {
            whatToSpawnClone = Instantiate(whatToSpawnPrefab, spawnLocations[i].transform.position, spawnLocations[i].transform.rotation);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
