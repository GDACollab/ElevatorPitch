using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public GameObject prefabManagers;
    void Start()
    {
        CharacterPrefabController playerControl;
        prefabManagers = GameObject.FindGameObjectWithTag("PCM");
        int count = 1;
        //for(int i = 0; i < prefabManagers.Length; i++)
        //{
            playerControl = prefabManagers.GetComponent<CharacterPrefabController>();
            playerControl.spawnPlayer(new Vector3(-1, count, 0), 0);
            count += 1;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
