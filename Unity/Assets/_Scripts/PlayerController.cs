using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;
    List<Collider2D> ObjectsTouchingFeet;

    //player specific attributes
    public int playerNo;

    //character specific attributes
    public float jumpForce;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ObjectsTouchingFeet = new List<Collider2D>();
        jumpForce *= 550;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Physics stuff
    void FixedUpdate() {
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0) {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        ObjectsTouchingFeet.Add(collision);
    }

    void OnTriggerExit2D(Collider2D collision) {
        ObjectsTouchingFeet.Remove(collision);
    }
}
