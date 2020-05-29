using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CharacterPrefabController : MonoBehaviour
{
    public GameObject moveTempPlayer;
    private PlayerInput playerInput;
    private int playerIndex;
    private GameObject gameModeObj;
    private int gameMode;
    PlayerControl playerControl;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex;
        DontDestroyOnLoad(transform);
        SceneManager.sceneLoaded += OnSceneLoaded;
        GetComponent<PlayerControl>().enabled = false;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameModeObj = GameObject.FindGameObjectWithTag("GameMode");
        //Debug.Log("Game mode: " + gameModeObj.GetComponent<WinCondition>().gameModeTemplate);
        gameMode = gameModeObj.GetComponent<WinCondition>().gameModeTemplate;
        playerControl = gameObject.GetComponent<PlayerControl>();
        playerControl.setGameMode(gameMode);
        if (!(scene.name == "quips") && !(scene.name == "CoffeeCupGame") && !(scene.name == "emailTemplate"))
        {
            if (scene.name == "Start")
            {
                spawnPlayer(new Vector3(0, 0, 0), 1);
            }
            else
            {
                spawnPlayer(new Vector3(0, 0, 0), 0);
            }

        }
        else if(scene.name == "CoffeeCupGame")
        {
            playerControl.findCoffeeArms();
            var a = GetComponent<PlayerControl>();
            a.enabled = true;
            a.setGameMode(gameMode); //Update gameMode in PlayerControl so it knows what controls to use
        } else if(scene.name == "emailTemplate") {
            playerControl.findEmailBars();
        }
    }

    public void spawnPlayer(Vector3 pos, int x)
    {
        GameObject p = Instantiate(moveTempPlayer, pos, Quaternion.identity);
        var BC = p.GetComponent<BoxCollider2D>();
        p.GetComponent<playerSetup>().setup(playerIndex, gameMode);
        var a = GetComponent<PlayerControl>();
        a.enabled = true;
        a.pawn = p;
        a.setGameMode(gameMode); //Update gameMode in PlayerControl so it knows what controls to use

        if (x == 1)
        {
            p.transform.localScale = new Vector3(.7f, .7f, 1);

            BC.offset = new Vector2(0, -1);
            BC.size = new Vector2(1.5f, .5f);
        }
        else
        {
            p.transform.localScale = new Vector3(.25f, .25f, 1);
            BC.offset = new Vector2(0, 0);
            BC.size = new Vector2(1.5f, 3.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public int getGameMode()
    {
        return gameMode;
    }
}
