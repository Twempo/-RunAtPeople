using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSelectionText : MonoBehaviour
{
    public GameObject playerSprites;
    public Text playerSelectionText;
    public double currentPlayer;
    public int GOON = 1;
    public int BOOF = 2;
    public Button goon, boof, kirk, color, confirm;
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
        color.onClick.AddListener(delegate { TaskWithParameters("Color Change Button"); });
        confirm.onClick.AddListener(delegate { TaskWithParameters("Confirm Button"); });

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
        //Debug.Log("You have clicked the button");
    }
    void TaskWithParameters(string message)
    {
        //Debug.Log("HAAAAAAAAAAAAAAALP");
        if (message.Equals("Boof Button") && currentPlayer == 1)
        {
            sprites.PlayerSelected("Player 1 Boof");
            //currentPlayer = 1.5;
        }
        else if (message.Equals("Goon Button") && currentPlayer == 1)
        {
            sprites.PlayerSelected("Player 1 Goon");
        }
        else if (message.Equals("Kirk Button") && currentPlayer == 1)
        {
            sprites.PlayerSelected("Player 1 Kirk");
            //Debug.Log("Player Uno Kirk.");
        }
        if (message.Equals("Boof Button") && currentPlayer == 2)
        {
            sprites.PlayerSelected("Player 2 Boof");
        }
        else if (message.Equals("Goon Button") && currentPlayer == 2)
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
        if (message.Equals("Color Change Button"))
        {
            Debug.Log("Player " + currentPlayer);
            sprites.PlayerSelected("Player " + currentPlayer);
            return;
        }
        if (message.Equals("Confirm Button") && currentPlayer == 2) 
        {
            //FindObjectOfType<SceneController>().EndCharSelect(player 1 color, player 2 color, player 1 character, player 2 character);
        }
        else if(message.Equals("Confirm Button"))
        {
            //Debug.Log(currentPlayer);
            sprites.PlayerSelected("Player "+currentPlayer+" Done");
            currentPlayer++;
        }
    }
}
