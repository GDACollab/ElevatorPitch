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
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex;
        DontDestroyOnLoad(transform);
        SceneManager.sceneLoaded += OnSceneLoaded;
        GetComponent<PlayerControl>().enabled = false;
        spawnPlayer(new Vector3(0,0,0));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(!(scene.name == "quips"))
        {
            spawnPlayer(new Vector3(0, 0, 0));
        }
    }

    public void spawnPlayer(Vector3 pos)
    {
        GameObject p = Instantiate(moveTempPlayer, pos, Quaternion.identity);
        p.GetComponent<playerSetup>().setup(playerIndex);
        var a = GetComponent<PlayerControl>();
        a.enabled = true;
        a.pawn = p;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
