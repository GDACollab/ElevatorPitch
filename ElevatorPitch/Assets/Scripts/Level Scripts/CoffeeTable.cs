using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTable : MonoBehaviour
{
    GameObject table;
    public int rotationMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.FindGameObjectWithTag("coffeeTable");
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
