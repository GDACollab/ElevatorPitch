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
    private GameObject spawnPoint;
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
        gameMode = gameModeObj.GetComponent<WinCondition>().gameModeTemplate;
        if (!(scene.name == "quips") && !(scene.name == "CoffeeCupGame"))
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
            var a = GetComponent<PlayerControl>();
            a.enabled = true;
            spawnPoint = GameObject.FindGameObjectWithTag("spawn" + playerIndex);
            switch (playerIndex)
            {
                case 0:
                    GameObject blazeArm = GameObject.FindGameObjectWithTag("blazeCoffeeArm");
                    blazeArm.transform.position = spawnPoint.transform.position;
                    break;
                case 1:
                    GameObject gianArm = GameObject.FindGameObjectWithTag("gianCoffeeArm");
                    gianArm.transform.position = spawnPoint.transform.position;
                    break;
                case 2:
                    GameObject robynArm = GameObject.FindGameObjectWithTag("robynCoffeeArm");
                    robynArm.transform.position = spawnPoint.transform.position;
                    break;
                case 3:
                    GameObject yeetArm = GameObject.FindGameObjectWithTag("yeetCoffeeArm");
                    yeetArm.transform.position = spawnPoint.transform.position;
                    break;
                default:
                    break;
            }
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
