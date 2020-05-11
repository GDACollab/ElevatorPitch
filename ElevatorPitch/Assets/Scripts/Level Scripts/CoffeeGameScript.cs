using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGameScript : MonoBehaviour
{

    GameObject table;
    GameObject robynMug;
    GameObject gianMug;
    GameObject blazeMug;
    GameObject yeetMug;
    public int rotationMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Get the table and mugs
        table = GameObject.FindGameObjectWithTag("coffeeTable");
        robynMug = GameObject.FindGameObjectWithTag("robynMug");
        gianMug = GameObject.FindGameObjectWithTag("gianMug");
        blazeMug = GameObject.FindGameObjectWithTag("blazeMug");
        yeetMug = GameObject.FindGameObjectWithTag("yeetMug");


    }

    // Update is called once per frame
    void Update()
    {
        if (table)
        {
            transform.Rotate(Vector3.back * rotationMultiplier);
        }
    }
}
