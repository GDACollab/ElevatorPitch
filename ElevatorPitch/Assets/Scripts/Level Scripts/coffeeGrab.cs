using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeGrab : MonoBehaviour
{
    persistentData persistentData;

    public Sprite blazeCoffeeGrabbed;
    public Sprite gianCoffeeGrabbed;
    public Sprite robynCoffeeGrabbed;
    public Sprite yeetCoffeeGrabbed;

    private GameObject blazeMug;
    private GameObject gianMug;
    private GameObject robynMug;
    private GameObject yeetMug;
    private bool blazeGrabbedMug = false;
    private bool gianGrabbedMug = false;
    private bool robynGrabbedMug = false;
    private bool yeetGrabbedMug = false;

    // Start is called before the first frame update
    void Start()
    {
        blazeMug = GameObject.FindGameObjectWithTag("blazeMug");
        gianMug = GameObject.FindGameObjectWithTag("gianMug");
        robynMug = GameObject.FindGameObjectWithTag("robynMug");
        yeetMug = GameObject.FindGameObjectWithTag("yeetMug");

        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (tag)
        {
            case "robynCoffeeArm":
                if(collider.transform.tag == "robynMug")
                {
                    Debug.Log("Hit robyn's mug!");
                    gameObject.GetComponent<SpriteRenderer>().sprite = robynCoffeeGrabbed;
                    Destroy(robynMug);
                    robynGrabbedMug = true;
                    persistentData.setFinishTime(2);
                    persistentData.complete[2] = true;
                    persistentData.timeUpdated[2] = true;
                }
                break;
            case "blazeCoffeeArm":
                if (collider.transform.tag == "blazeMug")
                {
                    Debug.Log("Hit blake's mug!");
                    gameObject.GetComponent<SpriteRenderer>().sprite = blazeCoffeeGrabbed;
                    Destroy(blazeMug);
                    blazeGrabbedMug = true;
                    persistentData.setFinishTime(0);
                    persistentData.complete[0] = true;
                    persistentData.timeUpdated[0] = true;
                }
                break;
            case "gianCoffeeArm":
                if (collider.transform.tag == "gianMug")
                {
                    Debug.Log("Hit gian's mug!");
                    gameObject.GetComponent<SpriteRenderer>().sprite = gianCoffeeGrabbed;
                    Destroy(gianMug);
                    gianGrabbedMug = true;
                    persistentData.setFinishTime(1);
                    persistentData.complete[1] = true;
                    persistentData.timeUpdated[1] = true;
                }
                break;
            case "yeetCoffeeArm":
                if (collider.transform.tag == "yeetMug")
                {
                    Debug.Log("Hit yeet's mug!");
                    gameObject.GetComponent<SpriteRenderer>().sprite = yeetCoffeeGrabbed;
                    Destroy(yeetMug);
                    yeetGrabbedMug = true;
                    persistentData.setFinishTime(3);
                    persistentData.complete[3] = true;
                    persistentData.timeUpdated[3] = true;
                }
                break;
            default:
                break;
        }
    }

    public bool GetGrabbedMug(int playerIndex)
    {
        switch (playerIndex) //0: Blaze, 1: Gian, 2: Robyn, 3: Yeet
        {
            case 0:
                return blazeGrabbedMug;
            case 1:
                return gianGrabbedMug;
            case 2:
                return robynGrabbedMug;
            case 3:
                return yeetGrabbedMug;
            default:
                return false;
        }
    }
}
