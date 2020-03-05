using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecilehorizontal : MonoBehaviour
{
    public GameObject projectile;
    private float timer = 0.0f;
    public float waitTime = 3.0f;
    private Vector2[] vert;
    public float thrust = 10.0f;
    public float rangesize;
    public float destroytime = 10f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //float ran = ((GetComponent<SpriteRenderer>().sprite.bounds.size.y)/2)* Random.Range(-1, 1);
        Vector2 place = new Vector2(transform.position.x, transform.position.y+Random.Range(-rangesize/2, rangesize / 2));

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = timer - waitTime;


            GameObject temp = Instantiate(projectile, place, transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * thrust);
            Destroy(temp, destroytime);

        }
    }
}
