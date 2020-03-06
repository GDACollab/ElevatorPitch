using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [Tooltip("Distance of left barrier from 0 (negative value).")]
    public float westWall;
    [Tooltip("Distance of right barrier from 0 (positive value).")]
    public float eastWall;
    [Tooltip("Distance of bottom barrier from 0 (negative value).")]
    public float southWall;
    [Tooltip("Distance of top barrier from 0 (positive value).")]
    public float northWall;
    private Vector2 boundsHorizontal;
    private Vector2 boundsVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        boundsHorizontal = new Vector2(northWall, southWall);
        boundsVertical = new Vector2(eastWall, westWall);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, boundsVertical.y, boundsVertical.x);
        playerPos.y = Mathf.Clamp(playerPos.y, boundsHorizontal.y, boundsHorizontal.x);
        transform.position = playerPos;
    }
}
