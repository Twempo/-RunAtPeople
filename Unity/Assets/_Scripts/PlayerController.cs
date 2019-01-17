using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //universal attributes
    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left
    float speedMulti = 1;
    List<Collider2D> ObjectsTouchingFeet;
    
    GameObject playerOne;
    GameObject playerTwo;
    
    private void Awake()
    {
        //Time.timeScale = (.25f);
        playerOne = GameObject.Find("PlayerOne");
        playerTwo = GameObject.Find("PlayerTwo");
    }
    public Collider2D footCollider;

    //player specific attributes
    public int playerNo;
    private float timeToJump;
    private float timeToBoof;

    //character specific attributes
    public float jumpForce;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ObjectsTouchingFeet = new List<Collider2D>();
        jumpForce *= 732;
        timeToJump = 0;
        timeToBoof = 0;
	}

    private void Update() {
        if(timeToJump > 0) {
            timeToJump -= Time.deltaTime;
        }
        if(timeToBoof > 0) {
            timeToBoof -= Time.deltaTime;
        }
    }

    //Physics stuff
    void FixedUpdate() {
        rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));
        //rb2d.GetContacts().
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0 && timeToJump <= 0) {
            Jump();
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
        {
            Jump();
        }
        foreach (Collider2D c in ObjectsTouchingFeet)
            Debug.Log(gameObject.name + ": " + c.name); 
    }

    IEnumerator DirSwitchSpeed()
    {
        speedMulti = 1.75f;
        yield return new WaitForSeconds(.5f);
        speedMulti = 1;
    }

    void SwitchDirection() {
        direction *= -1;
        //StartCoroutine(DirSwitchSpeed());
        timeToBoof = .35f;
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpForce);
        timeToJump = .5f;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && timeToBoof <=0)
        {
            SwitchDirection();
        }
        if (collision.gameObject.tag == "Wall")
        {
            SwitchDirection();
            if (((Input.GetAxis("P1.Jump") > 0) && playerNo == 1) || ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2)) {
                Jump();
            }
        }
        //ObjectsTouchingFeet.Add(collision);
        if (collision.gameObject.tag == "Floor")
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
