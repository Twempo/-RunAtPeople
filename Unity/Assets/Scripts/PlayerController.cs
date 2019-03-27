using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum Character {Boof, Goon, Kirk}
    public Character character;

    //universal attributes
    public GameManager gameManager;

    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left
    float speedMulti = 1;

    public Animator anim;

    public List<Collider2D> ObjectsTouchingFeet;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public Collider2D footCollider;
    public Collider2D headCollider;
    public float maxJumpSpeed = 5;

    //player specific attributes
    public int playerNo;
    public Vector2 playerPos;
    private float timeToJump;
    private float timeToBoof;
    public CapsuleCollider2D characterCollider;

    //character specific attributes
    public float jumpForce;
    public float moveSpeed;
    public float jumpSpeedMulti = 1;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ObjectsTouchingFeet = new List<Collider2D>();
        timeToJump = 0;
        timeToBoof = 0;
        playerPos = new Vector2(transform.position.x, transform.position.y);

        if(character == Character.Goon)
        {
            jumpForce = 1.875f;
            moveSpeed = 11f;
            characterCollider.size = new Vector2(1.62f, .8f);
            footCollider.offset = new Vector2(0, -.86f);
            headCollider.offset = new Vector2(0, .69f);
            headCollider.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if(character == Character.Boof)
        {
            jumpForce = 1.625f;
            moveSpeed = 16.3f;
            characterCollider.size = new Vector2(1.53f, .8f);
            footCollider.offset = new Vector2(0, -.7f);
            headCollider.offset = new Vector2(0, .39f);
            headCollider.gameObject.transform.localScale = new Vector3(.65f, 1, 1);
        }
        if (character == Character.Kirk) {
            jumpForce = 1.7f;
            moveSpeed = 9f;
            jumpSpeedMulti = 1.7f;
            characterCollider.size = new Vector2(1.62f, .8f);
            footCollider.offset = new Vector2(0, -.86f);
            headCollider.offset = new Vector2(0, .69f);
            headCollider.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        jumpForce *= 732;
    }

    private void Update() {
        playerPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        if(anim!=null && /*Physics2D.Raycast(transform.position, new Vector2(0, -1)).distance <= .75*/ObjectsTouchingFeet.ToArray().Length>0) {
            anim.SetBool("Jump", false);
            /*Debug.Log(playerNo + " Not Jump");
            Debug.DrawRay(transform.position, new Vector2(0, -.75f));*/
        }
        else if(anim != null)
        {
            anim.SetBool("Jump", true);
            /*Debug.Log(playerNo + " Jump");
            Debug.DrawRay(transform.position, new Vector2(0, -1));*/
        }
        if (timeToJump > 0) {
            timeToJump -= Time.deltaTime;
        }
        if(timeToBoof > 0) {
            timeToBoof -= Time.deltaTime;
        }
        if (anim != null)
            anim.SetInteger("Direction", direction);
        /*if(Physics2D.Raycast(playerPos, new Vector2(-1,0)).distance <= .75 && Physics2D.Raycast(playerPos, new Vector2(-1, 0)).collider.tag == "Player")
        {
            Debug.Log("huzzah!");
            SwitchDirection();
        }*/
        //Debug.Log(playerNo + "" + playerPos + "" + Physics2D.Raycast(playerPos, new Vector2(direction, 0)).distance);
    }

    //Physics stuff
    void FixedUpdate() {
        if (playerNo == 1 ? (Input.GetAxis("P1.Fall") > 0) : (Input.GetAxis("P2.Fall") > 0))
            rb2d.gravityScale = 4;
        else
            rb2d.gravityScale = 1;
        if(anim.GetBool("Jump"))
            rb2d.velocity = (new Vector2(moveSpeed * direction * jumpSpeedMulti, rb2d.velocity.y));
        else
            rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));
        //rb2d.GetContacts()
        Debug.Log(playerNo + ", " + ObjectsTouchingFeet.ToArray()[0].ToString());
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0 && timeToJump <= 0) {
            Jump();
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
        {
            //Debug.Log("in boof's jump method.");
            Jump();
        }
        /*foreach (Collider2D c in ObjectsTouchingFeet)
            Debug.Log(gameObject.name + ": " + c.name);*/
        if ((Physics2D.Raycast(new Vector2(playerPos.x, playerPos.y-.5f) + new Vector2(direction, 0) * 1.9f / 2, new Vector2(direction, 0)).distance <= .1) && timeToBoof <= 0)
        {
            //Debug.Log(playerNo + "" + playerPos + "" + Physics2D.Raycast(playerPos, new Vector2(direction, 0)).point);
            Debug.DrawRay(playerPos, new Vector2(direction, 0), Color.red, .5f);
            //Debug.Log(Physics2D.Raycast(playerPos + new Vector2(direction, 0) * .5f, new Vector2(direction, 0)).collider.name);
            SwitchDirection();
            if (((Input.GetAxis("P1.Jump") > 0) && playerNo == 1) || ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2) && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
            {
                //Debug.Log("HERE");
                Jump();
            }
        }
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
        //timeToBoof = .35f;  
    }

    void Jump()
    {
        //Debug.Log("In the jump mehtod");
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.isKinematic = true;
        rb2d.isKinematic = false;
        rb2d.AddForce(Vector2.up * jumpForce);
        if (rb2d.velocity.y > maxJumpSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxJumpSpeed);
        }
        timeToJump = .5f;
        /*if (anim != null)
            anim.SetBool("Jump", true);*/
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ObjectsTouchingFeet.Add(collision);

        /*if (collision.gameObject.tag == "Player" && Physics2D.Raycast(playerPos, new Vector2(0, 1)).distance <= .75) {
            Debug.Log(playerNo + " HIT SOMEONE AT: " + collision.transform.position.x + "," + collision.transform.position.y);
            Debug.DrawRay(playerPos, new Vector2(direction, 0), Color.cyan, .5f);
            SwitchDirection();
        }*/

        /*if (collision.gameObject.tag != "Player" && Physics2D.Raycast(playerPos, new Vector2(0, -1)).distance <= .75)
        {
            ObjectsTouchingFeet.Add(collision);
            if (anim != null)
                anim.SetBool("Jump", false);
            //Debug.Log("halp");
        }*/
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        ObjectsTouchingFeet.Remove(collision);
    }*/

    /*
    void Win(int playerNo)
    {

    }
    */
}
