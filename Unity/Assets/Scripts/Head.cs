using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    public int targetNo;
    public Collider2D colliderToLookFor;

    public GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision==colliderToLookFor)
            gameManager.Win(targetNo);
    }
}
