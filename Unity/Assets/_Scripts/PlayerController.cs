﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;

    //player specific attributes
    public int playerNo;

    //character specific attributes
    public int jumpHeight;
    public int moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Physics stuff
    void FixedUpdate() {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input)
    }
}
