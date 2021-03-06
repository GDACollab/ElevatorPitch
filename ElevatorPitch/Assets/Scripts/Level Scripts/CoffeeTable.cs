﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTable : MonoBehaviour
{
    GameObject table;
    public float rotationMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.FindGameObjectWithTag("coffeeTable");
    }

    // Update is called once per frame
    void Update()
    {
        if (table && Time.timeScale > 0)
        {
            transform.Rotate(Vector3.back * rotationMultiplier * Time.deltaTime * 150); //Made not dependent on framerate
        }
    }
}
