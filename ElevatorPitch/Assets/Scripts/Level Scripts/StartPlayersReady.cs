using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayersReady : MonoBehaviour
{
    private int playerCount = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        playerCount++;
    }
}
