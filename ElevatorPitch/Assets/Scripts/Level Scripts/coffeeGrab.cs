using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (this.tag)
        {
            case "robynCoffeeArm":
                if(collider.transform.tag == "robynMug")
                {
                    Debug.Log("Hit robyn's mug!");
                }
                break;
            case "blazeCoffeeArm":
                if (collider.transform.tag == "blazeMug")
                {
                    Debug.Log("Hit blake's mug!");
                }
                break;
            case "gianCoffeeArm":
                if (collider.transform.tag == "gianMug")
                {
                    Debug.Log("Hit gian's mug!");
                }
                break;
            case "yeetCoffeeArm":
                if (collider.transform.tag == "yeetMug")
                {
                    Debug.Log("Hit yeet's mug!");
                }
                break;
            default:
                break;
        }
    }
}
