using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public GameObject PlayerOneGoon, PlayerOneBoof, PlayerTwoGoon, PlayerTwoBoof, PlayerOneKirk, PlayerTwoKirk;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerSprites.GetChild("PlayerOneGoon").SetActive(true);
        //PlayerOneGoon.SetActive(false);
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
        //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSelected(string player_character)
    {
        if (player_character.Equals("Player 1 Boof"))
        {
            Debug.Log("Player One has selected Boof.");
            //var PlayerOneBoof1 = GameObject.Find("PlayerOneBoof");
            PlayerOneBoof.SetActive(true);
            // Debug.Log(PlayerOneBoof1);

        }
        else if (player_character.Equals("Player 1 Goon"))
        {
            //var PlayerOneGoon = GameObject.Find("PlayerOneGoon");
            PlayerOneGoon.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Boof"))
        {
            //var PlayerTwoBoof = GameObject.Find("PlayerTwoBoof");
            PlayerTwoBoof.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Goon"))
        {
            //var PlayerTwoGoon = GameObject.Find("PlayerTwoGoon");
            PlayerTwoGoon.SetActive(true);
        }
        else if (player_character.Equals("Player 1 Kirk"))
        {
            //var PlayerTwoBoof = GameObject.Find("PlayerTwoBoof");
            PlayerOneKirk.SetActive(true);
        }
        else if (player_character.Equals("Player 2 Kirk"))
        {
            //var PlayerTwoGoon = GameObject.Find("PlayerTwoGoon");
            PlayerTwoKirk.SetActive(true);
        }
    }
}
