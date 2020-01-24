using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerspawn : MonoBehaviour
{
    public GameObject cubeObj;
    public bool respawn = false;
    //using public
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cubeObj, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            Instantiate(cubeObj, transform.position, transform.rotation);
        }
    }
}
