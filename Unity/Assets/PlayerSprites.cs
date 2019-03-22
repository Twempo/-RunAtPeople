using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public GameObject PlayerOneGoon, PlayerOneBoof, PlayerTwoGoon, PlayerTwoBoof, PlayerOneKirk, PlayerTwoKirk;
    //color changing code
    public SpriteRenderer m_SpriteRenderer;
    public Color color;
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
    }
}
