using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public GameObject PlayerOneGoon, PlayerOneBoof, PlayerTwoGoon, PlayerTwoBoof, PlayerOneKirk, PlayerTwoKirk;
    //color changing code
    public SpriteRenderer sp_PlayerOneGoon, sp_PlayerOneBoof, sp_PlayerTwoGoon, sp_PlayerTwoBoof, sp_PlayerOneKirk, sp_PlayerTwoKirk;
    public Color red, green, grey, blue;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOneGoon = GameObject.Find("/Canvas/PlayerSprites/PlayerOneGoon");
        PlayerOneGoon.SetActive(false);
        PlayerOneBoof = GameObject.Find("/Canvas/PlayerSprites/PlayerOneBoof");
        PlayerOneBoof.SetActive(false);
        PlayerTwoGoon = GameObject.Find("/Canvas/PlayerSprites/PlayerTwoGoon");
        PlayerTwoGoon.SetActive(false);
        PlayerTwoBoof = GameObject.Find("/Canvas/PlayerSprites/PlayerTwoBoof");
        PlayerTwoBoof.SetActive(false);
        PlayerOneKirk = GameObject.Find("/Canvas/PlayerSprites/PlayerOneKirk");
        PlayerTwoKirk.SetActive(false);
        PlayerTwoKirk = GameObject.Find("/Canvas/PlayerSprites/PlayerTwoKirk");
        PlayerTwoKirk.SetActive(false);

        //colors
        red = new Color(255, 0, 0);
        green = Color.green;
        grey = new Color(175, 175, 175);
        blue = new Color(0, 255, 246);
        sp_PlayerOneGoon = PlayerOneGoon.GetComponent<SpriteRenderer>();
        sp_PlayerOneBoof = PlayerOneBoof.GetComponent<SpriteRenderer>();
        sp_PlayerTwoGoon = PlayerTwoGoon.GetComponent<SpriteRenderer>();
        sp_PlayerTwoBoof = PlayerTwoBoof.GetComponent<SpriteRenderer>();
        sp_PlayerOneKirk = PlayerOneKirk.GetComponent<SpriteRenderer>();
        sp_PlayerTwoKirk = PlayerTwoKirk.GetComponent<SpriteRenderer>();

        sp_PlayerOneGoon.color = red;
        sp_PlayerOneBoof.color = green;
        sp_PlayerTwoGoon.color = red;
        sp_PlayerTwoBoof.color = green;
        sp_PlayerOneKirk.color = blue;
        sp_PlayerTwoKirk.color = blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSelected(string player_character)
    {
        //Which player are currently active
        
        //Character Activation
        if (player_character.Equals("Player 1 Boof"))
        {
            //Debug.Log("Player One has selected Boof.");
            PlayerOneBoof.SetActive(true);
        }
        else if (player_character.Equals("Player 1 Goon"))
        {
            PlayerOneGoon.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Boof"))
        {
            PlayerTwoBoof.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Goon"))
        {
            PlayerTwoGoon.SetActive(true);
        }
        else if (player_character.Equals("Player 1 Kirk"))
        {
            PlayerOneKirk.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Kirk"))
        {
            PlayerTwoKirk.SetActive(true);
        }

        //Player Colors
        if (player_character.Equals("Player 1"))
        {
            if (PlayerOneGoon.active)
            {
                if (sp_PlayerOneGoon.color == red)
                {
                    sp_PlayerOneGoon.color = blue;
                }
                else if (sp_PlayerOneGoon.color == blue)
                {
                    sp_PlayerOneGoon.color = green;
                }
                else if (sp_PlayerOneGoon.color == green)
                {
                    sp_PlayerOneGoon.color = grey;
                }
                else if (sp_PlayerOneGoon.color == grey)
                {
                    sp_PlayerOneGoon.color = red;
                }
            }
            if (PlayerOneBoof.active)
            {
                if (sp_PlayerOneBoof.color == red)
                {
                    sp_PlayerOneBoof.color = blue;
                }
                else if (sp_PlayerOneBoof.color == blue)
                {
                    sp_PlayerOneBoof.color = green;
                }
                else if (sp_PlayerOneBoof.color == green)
                {
                    sp_PlayerOneBoof.color = grey;
                }
                else if (sp_PlayerOneBoof.color == grey)
                {
                    sp_PlayerOneBoof.color = red;
                }
            }
        }
        if(player_character.Equals("Player 2"))
        { 
            if (PlayerTwoGoon.active)
            {
                if (sp_PlayerTwoGoon.color == red)
                {
                    sp_PlayerTwoGoon.color = blue;
                }
                else if (sp_PlayerTwoGoon.color == blue)
                {
                    sp_PlayerTwoGoon.color = green;
                }
                else if (sp_PlayerTwoGoon.color == green)
                {
                    sp_PlayerTwoGoon.color = grey;
                }
                else if (sp_PlayerTwoGoon.color == grey)
                {
                    sp_PlayerTwoGoon.color = red;
                }
            }
            if (PlayerTwoBoof.active)
            {
                Debug.Log("BOOOOOOOOOOOOOOOOOF");
                if (sp_PlayerTwoBoof.color == red)
                {
                    sp_PlayerTwoBoof.color = blue;
                }
                else if (sp_PlayerTwoBoof.color == blue)
                {
                    sp_PlayerTwoBoof.color = green;
                }
                else if (sp_PlayerTwoBoof.color == green)
                {
                    sp_PlayerTwoBoof.color = grey;
                }
                else if (sp_PlayerTwoBoof.color == grey)
                {
                    sp_PlayerTwoBoof.color = red;
                }
            }
        }
    }
}
