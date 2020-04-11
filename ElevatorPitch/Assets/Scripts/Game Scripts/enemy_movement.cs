using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float thrust = 1.1f;
    public float waitTime = 2.0f;
    private Rigidbody2D self;
    public float pausetime = 3.0f;
    //private float timer = 0.0f;
    public float endpos = 4.0f;
    public Vector3 start; 
    public bool moveleftright = false;
    public bool moverightleft = false;
    public bool moveupdown = false;
    //private bool swit = false;
    // Start is called before the first frame update
    void Start()
    {
        start = this.gameObject.transform.position;
        self = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (moverightleft)
        {
            if (start.x + endpos < this.gameObject.transform.position.x)
            {
                self.AddForce(-transform.right * thrust);
            }
            else if (start.x + endpos> this.gameObject.transform.position.x)
            {
                self.AddForce(transform.right * thrust);
            }
        } 
        else if (moveleftright)
        {
            if (start.x - endpos > this.gameObject.transform.position.x)
            {
                self.AddForce(transform.right * thrust);
            }
            else if (start.x - endpos < this.gameObject.transform.position.x)
            {
                self.AddForce(-transform.right * thrust);
            }
        }
        else if (moveupdown)
        {
            if (start.y + endpos < this.gameObject.transform.position.y)
            {
                self.AddForce(-transform.up * thrust);
            }
            else if (start.y + endpos > this.gameObject.transform.position.y)
            {
                self.AddForce(transform.up * thrust);
            }
        }
        
    }
}
