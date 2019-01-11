using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;
    private int direction; // 1 = right, -1 = left

    //player specific attributes
    public int playerNo;

    //character specific attributes
    public int jumpHeight;
    public int moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        direction = 1;
	}

    //Physics stuff
    void FixedUpdate() {
        rb2d.velocity.Set(moveSpeed*direction, rb2d.velocity.y);
        //rb2d.GetContacts().
    }

    void switchDirection() {
        direction *= -1;
    }
}
