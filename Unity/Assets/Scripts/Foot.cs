using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {

    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && Physics2D.Raycast(player.playerPos, new Vector2(0, -1)).distance <= .75)
        {
            player.ObjectsTouchingFeet.Add(collision);
            if (player.anim != null)
                player.anim.SetBool("Jump", false);
            //Debug.Log("halp");
        }
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        player.ObjectsTouchingFeet.Remove(collision);
    }
}
