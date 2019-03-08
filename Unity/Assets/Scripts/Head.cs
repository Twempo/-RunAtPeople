using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
<<<<<<< HEAD
    public int targetNo;
    public Collider2D colliderToLookFor;

=======
    public int playerNo;
    float timeToWin = 1;
>>>>>>> c5db319b889de8ef2822963caae350aa39d15544
    public GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update(){
        if (timeToWin > 0)
        {
            timeToWin -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
<<<<<<< HEAD
        if (collision==colliderToLookFor)
            gameManager.Win(targetNo);
=======
        if (collision.CompareTag("Player") && gameManager != null&&timeToWin<=0)
        {
            Debug.Log("Adding one point.");
            gameManager.Win(playerNo);
            timeToWin = 1;
        }
>>>>>>> c5db319b889de8ef2822963caae350aa39d15544
    }
}
