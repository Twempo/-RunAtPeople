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
    private Vector2 playerPos;
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
        playerPos = new Vector2(transform.position.x, transform.position.y + 1f);
	}

    private void Update() {
        playerPos = new Vector2(transform.position.x, transform.position.y + 1f);
        if (timeToJump > 0) {
            timeToJump -= Time.deltaTime;
        }
        if(timeToBoof > 0) {
            timeToBoof -= Time.deltaTime;
        }
        /*if(Physics2D.Raycast(playerPos, new Vector2(-1,0)).distance <= .75 && Physics2D.Raycast(playerPos, new Vector2(-1, 0)).collider.tag == "Player")
        {
            Debug.Log("huzzah!");
            SwitchDirection();
        }*/
        //Debug.Log(playerNo + "" + playerPos + "" + Physics2D.Raycast(playerPos, new Vector2(direction, 0)).distance);
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

        /*foreach (Collider2D c in ObjectsTouchingFeet)
            Debug.Log(gameObject.name + ": " + c.name);*/
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

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && Physics2D.Raycast(playerPos, new Vector2(0, -1)).distance <= .75) {
            Debug.Log(playerNo + " HIT SOMEONE AT: " + collision.transform.position.x + "," + collision.transform.position.y);
            Win(playerNo);
        }
        else if (collision.gameObject.tag == "Player" && timeToBoof <= 0) {
            SwitchDirection();
        }
        if (/*collision.gameObject.tag == "Wall"*/(collision.gameObject.tag != "Player" && Physics2D.Raycast(playerPos,new Vector2(direction,0)).distance<=.75))
        {
            Debug.Log(playerNo + "" + playerPos + "" + Physics2D.Raycast(playerPos, new Vector2(direction, 0)).distance);
            SwitchDirection();
            if (((Input.GetAxis("P1.Jump") > 0) && playerNo == 1) || ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2)) {
                Jump();
            }
        }
        //ObjectsTouchingFeet.Add(collision);
        if (collision.gameObject.tag != "Player" && Physics2D.Raycast(playerPos, new Vector2(0, -1)).distance <= .75)
        {
            ObjectsTouchingFeet.Add(collision);
            //Debug.Log("halp");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ObjectsTouchingFeet.Remove(collision);
    }

    void Win(int playerNo)
    {

    }
}
