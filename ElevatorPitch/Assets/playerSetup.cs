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
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        int playerIndex = playerInput.playerIndex;
        sr.sprite = playerSprites[playerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
