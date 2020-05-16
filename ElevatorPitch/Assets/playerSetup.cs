using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerSetup : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    public Sprite[] playerSprites;
    public Sprite[] armSprites;
    private SpriteRenderer sr;
    public int controllerIndex = -1;
    public GoalComplete gc;
    private GameObject spawnpoint;
    private Animator anim;
    private Rigidbody2D rb;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gc = GetComponent<GoalComplete>();
        playerInput = GetComponent<PlayerInput>();

    }

    public void setup(int index, int gameMode)
    {
        controllerIndex = index;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[controllerIndex];

        gc.playerIndex = controllerIndex;
        spawnpoint = GameObject.FindGameObjectWithTag("spawn" + index);
        //if (spawnpoint != null)
        //{
        transform.position = spawnpoint.transform.position;
        anim.SetInteger("charIndex", index);
        spawnpoint.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("XVEL : " + rb.velocity.x);
        //anim.SetFloat("xVel", Mathf.Abs(rb.velocity.x));
    }

    private void OnEnable()
    {
        //playerInput.enabled = true;
    }
}
