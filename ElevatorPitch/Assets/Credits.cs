using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    Animator controller;
    persistentData pd;

    public float timerMax = 33;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
        pd = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>();
        timer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            pd.playAgain();
        }
    }
}
