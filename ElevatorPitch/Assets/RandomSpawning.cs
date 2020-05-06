using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawning : MonoBehaviour
{
    public List<GameObject> randompositions = new List<GameObject>();
    //determines if positions are random or not
    public bool randompos = true;
 
    // Start is called before the first frame update
    void Start()
    {
        //accessing our positions.
        randompositions.Add(this.gameObject.transform.GetChild(0).gameObject);
        randompositions.Add(this.gameObject.transform.GetChild(1).gameObject);
        randompositions.Add(this.gameObject.transform.GetChild(2).gameObject);
        randompositions.Add(this.gameObject.transform.GetChild(3).gameObject);
        if (randompos)
        {
            //changing our variables to a random position
            randompositions[0].transform.position = randompositions[Random.Range(0, 4)].transform.position;
            randompositions[1].transform.position = randompositions[Random.Range(0, 4)].transform.position;
            randompositions[2].transform.position = randompositions[Random.Range(0, 4)].transform.position;
            randompositions[3].transform.position = randompositions[Random.Range(0, 4)].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
