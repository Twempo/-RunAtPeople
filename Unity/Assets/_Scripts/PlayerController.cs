using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left
    List<Collider2D> ObjectsTouchingFeet;

    GameObject playerOne;
    GameObject playerTwo;

    private void Awake()
    {
        playerOne = GameObject.Find("PlayerOne");
        playerTwo = GameObject.Find("PlayerTwo");
    }

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
        rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));


        //rb2d.GetContacts().
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0) {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    void switchDirection() {
        direction *= -1;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }

        ObjectsTouchingFeet.Add(collision);
    }

    void OnTriggerExit2D(Collider2D collision) {
        ObjectsTouchingFeet.Remove(collision);
    }
}
