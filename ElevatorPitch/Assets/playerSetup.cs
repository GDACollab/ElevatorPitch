using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerSetup : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    public Sprite[] playerSprites;
    private SpriteRenderer sr;
    public int controllerIndex = -1;
    public GoalComplete gc;
    void Awake()
    {
        gc = GetComponent<GoalComplete>();
        playerInput = GetComponent<PlayerInput>();
    }
     
    public void setup(int index)
    {
        controllerIndex = index;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[controllerIndex];
        gc.playerIndex = controllerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //playerInput.enabled = true;
    }
}
