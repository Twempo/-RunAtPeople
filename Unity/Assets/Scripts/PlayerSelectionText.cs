using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSelectionText : MonoBehaviour
{
    public GameObject playerSprites;

    public Text playerSelectionText;
    public int currentPlayer;
    public int GOON = 1;
    public int BOOF = 2;
    public Button goon, boof, kirk;
    public PlayerSprites sprites;
    //Start is called before the first frame update
    void Start()
    {
        //sprites = new PlayerSprites();
        //PlayerSprites sprites = PlayerSprites.AddComponent<PlayerSprites>();

        currentPlayer = 1;
        playerSelectionText.text = "Player " + currentPlayer + " please pick your character.";
        
        goon.onClick.AddListener(delegate { TaskWithParameters("Goon Button"); });
        boof.onClick.AddListener(delegate { TaskWithParameters("Boof Button"); });
        kirk.onClick.AddListener(delegate { TaskWithParameters("Kirk Button"); });

        Instantiate(sprites, Vector3.zero, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        //update
        playerSelectionText.text = "Player " + currentPlayer + " please pick your character.";
    }
    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button");
    }
    void TaskWithParameters(string message)
    {
        Debug.Log(message);
        if(message.Equals("Boof Button") && currentPlayer==1)
        {
            sprites.PlayerSelected("Player 1 Boof");
        }
        else if(message.Equals("Goon Button") && currentPlayer==1)
        {
            sprites.PlayerSelected("Player 1 Goon");
        }
        else if (message.Equals("Kirk Button") && currentPlayer == 1)
        {
            sprites.PlayerSelected("Player 1 Kirk");
            Debug.Log("Player Uno Kirk.");
        }

        if (message.Equals("Boof Button") && currentPlayer==2)
        {
            sprites.PlayerSelected("Player 2 Boof");
        }
        else if(message.Equals("Goon Button") && currentPlayer==2)
        {
            sprites.PlayerSelected("Player 2 Goon");
        }
        else if (message.Equals("Kirk Button") && currentPlayer == 2)
        {
            sprites.PlayerSelected("Player 2 Kirk");
        }

        if (message.Equals("Boof Button") && currentPlayer == 3)
        {
            sprites.PlayerSelected("Player 3 Boof");
        }
        else if (message.Equals("Goon Button") && currentPlayer == 3)
        {
            sprites.PlayerSelected("Player 3 Goon");
        }
        else if (message.Equals("Kirk Button") && currentPlayer == 3)
        {
            sprites.PlayerSelected("Player 3 Kirk");
        }

        currentPlayer++;
    }
}
