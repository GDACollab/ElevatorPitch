using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public float horizontalWall;
    public float verticalWall;
    private Vector2 bounds;
    
    // Start is called before the first frame update
    void Start()
    {
        bounds = new Vector2(horizontalWall * -1, verticalWall * -1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, bounds.x, bounds.x * -1);
        playerPos.y = Mathf.Clamp(playerPos.y, bounds.y, bounds.y * -1);
        transform.position = playerPos;
    }
}
