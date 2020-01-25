//Designed By Sam Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    /*
    public float speed = 20;
    InputMaster controls;
   
    Vector2 move;
    
    void Awake()
    {
        controls = new InputMaster();
        controls.IngameControls.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.IngameControls.Movement.canceled += ctx => move = Vector2.zero;
        controls.IngameControls.Movement.performed += ctx => onMovement();

        //controls.IngameControls.Buttons.performed += ctx => move = ctx.ReadValue<>();
    }
    */
    /*
    private void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }
    
    void OnEnable()
    {
        controls.IngameControls.Enable();
    }
    void OnDisable()
    {
        controls.IngameControls.Disable();
    }
    */
}
