using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public GameObject PlayerOneGoon, PlayerOneBoof, PlayerTwoGoon, PlayerTwoBoof, PlayerOneKirk, PlayerTwoKirk, PlayerOneKirkStatic, PlayerTwoKirkStatic;
    //color changing code
    public SpriteRenderer sp_PlayerOneGoon, sp_PlayerOneBoof, sp_PlayerTwoGoon, sp_PlayerTwoBoof, sp_PlayerOneKirk, sp_PlayerTwoKirk;
    public Color red, green, grey, blue, forbidden;
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
        PlayerOneKirk.SetActive(false);
        PlayerTwoKirk = GameObject.Find("/Canvas/PlayerSprites/PlayerTwoKirk");
        PlayerTwoKirk.SetActive(false);
        //PlayerOneKirkStatic = GameObject.Find("/Canvas/PlayerSprites/PlayerOneKirkStatic");
        PlayerOneKirkStatic.SetActive(false);
       // PlayerTwoKirkStatic = GameObject.Find("/Canvas/PlayerSprites/PlayerTwoKirkStatic");
        PlayerTwoKirkStatic.SetActive(false);

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
        sp_PlayerOneBoof.color = red;
        sp_PlayerTwoGoon.color = green;
        sp_PlayerTwoBoof.color = green;
        sp_PlayerOneKirk.color = red;
        sp_PlayerTwoKirk.color = green;
    }

    public PlayerController.Character GetPlayerOne()
    {
        if (PlayerOneBoof.active)
            return PlayerController.Character.Boof;
        else if (PlayerOneKirk.active)
            return PlayerController.Character.Kirk;
        else
            return PlayerController.Character.Goon;
    }

    public PlayerController.Character GetPlayerTwo()
    {
        if (PlayerTwoBoof.active)
            return PlayerController.Character.Boof;
        else if (PlayerTwoKirk.active)
            return PlayerController.Character.Kirk;
        else
            return PlayerController.Character.Goon;
    }
    public Color GetPlayerOneColor()
    {
        if (PlayerOneBoof.active)
            return sp_PlayerOneBoof.color;
        else if (PlayerOneKirk.active)
            return sp_PlayerOneKirk.color;
        else
            return sp_PlayerOneGoon.color;
    }
    public Color GetPlayerTwoColor()
    {
        if (PlayerTwoBoof.active)
            return sp_PlayerTwoBoof.color;
        else if (PlayerOneKirk.active)
            return sp_PlayerTwoKirk.color;
        else
            return sp_PlayerTwoGoon.color;
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
            Debug.Log("In the boof method");
            PlayerOneBoof.SetActive(true);
            PlayerOneGoon.SetActive(false);
            PlayerOneKirk.SetActive(false);
            PlayerOneKirkStatic.SetActive(false);
            //return;
        }
        else if (player_character.Equals("Player 1 Goon"))
        {
            PlayerOneBoof.SetActive(false);
            PlayerOneGoon.SetActive(true);
            PlayerOneKirk.SetActive(false);
            PlayerOneKirkStatic.SetActive(false);
        }
        else if (player_character.Equals("Player 2 Boof"))
        {
            PlayerTwoBoof.SetActive(true);
            PlayerTwoGoon.SetActive(false);
            PlayerTwoKirk.SetActive(false);
            PlayerTwoKirkStatic.SetActive(false);
        }
        else if (player_character.Equals("Player 2 Goon"))
        {
            PlayerTwoBoof.SetActive(false);
            PlayerTwoGoon.SetActive(true);
            PlayerTwoKirk.SetActive(false);
            PlayerTwoKirkStatic.SetActive(false);
        }
        else if (player_character.Equals("Player 1 Kirk"))
        {
            PlayerOneBoof.SetActive(false);
            PlayerOneGoon.SetActive(false);
            PlayerOneKirk.SetActive(true);
            PlayerOneKirkStatic.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Kirk"))
        {
            PlayerTwoBoof.SetActive(false);
            PlayerTwoGoon.SetActive(false);
            PlayerTwoKirk.SetActive(true);
            PlayerTwoKirkStatic.SetActive(true);
        }
        //Disable player one's color for player two
        if (player_character.Equals("Player 1 Done"))
        {
            if (PlayerOneBoof.active)
                forbidden = sp_PlayerOneBoof.color;
            else if (PlayerOneGoon.active)
                forbidden = sp_PlayerOneGoon.color;
            else if (PlayerOneKirk.active)
                forbidden = sp_PlayerOneKirk.color;
            if(forbidden == green)
            {
                sp_PlayerTwoBoof.color = red;
                sp_PlayerTwoGoon.color = red;
                sp_PlayerTwoKirk.color = red;
            }
        }
        //Player Colors
        if (player_character.Equals("Player 1") && !PlayerTwoGoon.active && !PlayerTwoBoof.active)
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
            if (PlayerOneKirk.active)
            {
                if (sp_PlayerOneKirk.color == red)
                {
                    sp_PlayerOneKirk.color = blue;
                }
                else if (sp_PlayerOneKirk.color == blue)
                {
                    sp_PlayerOneKirk.color = green;
                }
                else if (sp_PlayerOneKirk.color == green)
                {
                    sp_PlayerOneKirk.color = grey;
                }
                else if (sp_PlayerOneKirk.color == grey)
                {
                    sp_PlayerOneKirk.color = red;
                }
            }
        }
        if(player_character.Equals("Player 2"))
        { 
            if (PlayerTwoGoon.active)
            {
                if (sp_PlayerTwoGoon.color == red && forbidden!=blue)
                {
                    sp_PlayerTwoGoon.color = blue;
                }
                else if (sp_PlayerTwoGoon.color == blue && forbidden != green)
                {
                    sp_PlayerTwoGoon.color = green;
                }
                else if (sp_PlayerTwoGoon.color == green && forbidden != grey)
                {
                    sp_PlayerTwoGoon.color = grey;
                }
                else if (sp_PlayerTwoGoon.color == grey && forbidden != red)
                {
                    sp_PlayerTwoGoon.color = red;
                }
                else if (sp_PlayerTwoGoon.color == grey && forbidden == red)
                    sp_PlayerTwoGoon.color = blue;
                else if (sp_PlayerTwoGoon.color == red && forbidden == blue)
                    sp_PlayerTwoGoon.color = green;
                else if (sp_PlayerTwoGoon.color == blue && forbidden == green)
                    sp_PlayerTwoGoon.color = grey;
                else if (sp_PlayerTwoGoon.color == green && forbidden == grey)
                    sp_PlayerTwoGoon.color = red;
            }
            if (PlayerTwoBoof.active)
            {
                //Debug.Log("BOOOOOOOOOOOOOOOOOF");
                if (sp_PlayerTwoBoof.color == red && forbidden != blue)
                {
                    sp_PlayerTwoBoof.color = blue;
                }
                else if (sp_PlayerTwoBoof.color == blue && forbidden != green)
                {
                    sp_PlayerTwoBoof.color = green;
                }
                else if (sp_PlayerTwoBoof.color == green && forbidden != grey)
                {
                    sp_PlayerTwoBoof.color = grey;
                }
                else if (sp_PlayerTwoBoof.color == grey && forbidden != red)
                {
                    sp_PlayerTwoBoof.color = red;
                }
                else if (sp_PlayerTwoBoof.color == grey && forbidden == red)
                    sp_PlayerTwoBoof.color = blue;
                else if (sp_PlayerTwoBoof.color == red && forbidden == blue)
                    sp_PlayerTwoBoof.color = green;
                else if (sp_PlayerTwoBoof.color == blue && forbidden == green)
                    sp_PlayerTwoBoof.color = grey;
                else if (sp_PlayerTwoBoof.color == green && forbidden == grey)
                    sp_PlayerTwoBoof.color = red;
            }
            if (PlayerTwoKirk.active)
            {
                //Debug.Log("BOOOOOOOOOOOOOOOOOF");
                if (sp_PlayerTwoKirk.color == red && forbidden != blue)
                {
                    sp_PlayerTwoKirk.color = blue;
                }
                else if (sp_PlayerTwoKirk.color == blue && forbidden != green)
                {
                    sp_PlayerTwoKirk.color = green;
                }
                else if (sp_PlayerTwoKirk.color == green && forbidden != grey)
                {
                    sp_PlayerTwoKirk.color = grey;
                }
                else if (sp_PlayerTwoKirk.color == grey && forbidden != red)
                {
                    sp_PlayerTwoKirk.color = red;
                }
                else if (sp_PlayerTwoKirk.color == grey && forbidden == red)
                    sp_PlayerTwoKirk.color = blue;
                else if (sp_PlayerTwoKirk.color == red && forbidden == blue)
                    sp_PlayerTwoKirk.color = green;
                else if (sp_PlayerTwoKirk.color == blue && forbidden == green)
                    sp_PlayerTwoKirk.color = grey;
                else if (sp_PlayerTwoKirk.color == green && forbidden == grey)
                    sp_PlayerTwoKirk.color = red;
            }
        }
    }
}
