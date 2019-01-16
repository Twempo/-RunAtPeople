using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left
    List<Collider2D> ObjectsTouchingFeet;

    //player specific attributes
    public int playerNo;
    private float timeToJump;

    //character specific attributes
    public float jumpForce;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ObjectsTouchingFeet = new List<Collider2D>();
        jumpForce *= 732;
        timeToJump = 0;
	}

    private void Update() {
        if(timeToJump > 0)
        {
            timeToJump -= Time.deltaTime;
        }
    }

    //Physics stuff
    void FixedUpdate() {
        rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));

        //rb2d.GetContacts().
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0 && timeToJump <= 0) {
            rb2d.velocity = new Vector2(rb2d.velocity.x,0);
            rb2d.AddForce(Vector2.up * jumpForce);
            timeToJump = .5f;
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpForce);
            timeToJump = .5f;
        }
        foreach (Collider2D c in ObjectsTouchingFeet)
            Debug.Log(gameObject.name + ": " + c.name); 
    }

    void switchDirection() {
        direction *= -1;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (timeToJump <= 0)
        {
            ObjectsTouchingFeet.Add(collision);
            Debug.Log("halp");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ObjectsTouchingFeet.Remove(collision);
    }
}
