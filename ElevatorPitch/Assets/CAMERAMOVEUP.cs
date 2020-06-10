using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERAMOVEUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            transform.Translate(new Vector3(0, -4, 0) * Time.deltaTime);
        }
    }
}
