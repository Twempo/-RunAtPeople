using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    public int playerToScore;
    float timeToWin = 1;
    public GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType  <GameManager>();
    }

    private void Update(){
        if (timeToWin > 0)
        {
            timeToWin -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && gameManager != null&&timeToWin<=0)
        {
            Debug.Log("Adding one point.");
            gameManager.Win(playerToScore);
            timeToWin = 1;
        }
    }
}
