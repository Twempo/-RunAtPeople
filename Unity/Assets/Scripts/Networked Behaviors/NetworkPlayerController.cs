using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour {
    public enum Character { Boof, Goon }
    public Character character;

    //universal attributes
    public NetworkGameManager gameManager;

    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left

    public Animator anim;

    List<Collider2D> ObjectsTouchingFeet;

    public Collider2D player1Collider;
    public Collider2D player2Collider;

    private void Awake() {
        gameManager = FindObjectOfType<NetworkGameManager>();
    }

    public Collider2D footCollider;

    //player specific attributes
    public int playerNo;
    public int playerControlSpot;

    private Vector2 playerPos;
    private float timeToJump;
    private float timeToBoof;

    //character specific attributes
    public float jumpForce;
    public float moveSpeed;

    //network behavior variables
    public float jumpInput;
    public float fallInput;

    /** Use this for initialization
     *  Sets initial values for variables
     */ 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ObjectsTouchingFeet = new List<Collider2D>();
        timeToJump = 0;
        timeToBoof = 0;
        playerPos = new Vector2(transform.position.x, transform.position.y);

        if (character == Character.Goon) {
            jumpForce = 1.55f;
            moveSpeed = 11f;
            footCollider.offset = new Vector2(0, -.86f);
        }
        if (character == Character.Boof) {
            jumpForce = 1.425f;
            moveSpeed = 12.5f;
            footCollider.offset = new Vector2(0, -.78f);
        }
        jumpForce *= 732;
    }
    
    /**
     * updates once per frame / every frame
     */ 
    private void Update()
    {
        playerPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        if (timeToJump > 0) 
            timeToJump -= Time.deltaTime;
        if (timeToBoof > 0)
            timeToBoof -= Time.deltaTime;
        if (anim != null)
            anim.SetInteger("Direction", direction);
    }

    /**
     * updates every physics update
     */
    void FixedUpdate()
    {
        rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));
        if ((jumpInput > 0) && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
        {
            Jump();
        }
        if (playerNo == 1 ? (Input.GetAxis("P1.Fall") > 0) : (Input.GetAxis("P2.Fall") > 0))
            rb2d.gravityScale = 4;
        else
            rb2d.gravityScale = 1;
        
        if ((Physics2D.Raycast(playerPos + new Vector2(direction, 0) * 1.5f / 2, new Vector2(direction, 0)).distance <= .1) && timeToBoof <= 0) 
        {
            if (Physics2D.Raycast(playerPos + new Vector2(direction, 0) * .5f, new Vector2(direction, 0)).collider == (playerNo == 1 ? player1Collider : player2Collider))
                return;
            SwitchDirection();
            if (((Input.GetAxis("P1.Jump") > 0) && playerNo == 1) || ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2) && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
                Jump();
        }
    }
    /**
     * Changes direction if player hits the wall
     */
    void SwitchDirection() {
        direction *= -1;
        timeToBoof = .35f;
    }

    /**
     * Applies the force in order to Jump and resets the Jump timer
     */
    void Jump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpForce);
        timeToJump = .5f;
        if (anim != null)
            anim.SetBool("Jump", true);
    }

    /**
     * Checks and manages the player box collider
     */ 
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "Player" && Physics2D.Raycast(playerPos, new Vector2(0, -1)).distance <= .75) {
            ObjectsTouchingFeet.Add(collision);
            if (anim != null)
                anim.SetBool("Jump", false);
        }
        if(collision.gameObject.tag == "Player" && timeToBoof <= 0) {
            SwitchDirection();
        }
    }
    void OnTriggerExit2D(Collider2D collision){ ObjectsTouchingFeet.Remove(collision); }
}