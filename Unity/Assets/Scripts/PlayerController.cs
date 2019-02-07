using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum Character {Boof, Goon}
    public Character character;

    //universal attributes
    Rigidbody2D rb2d;
    public int direction; // 1 = right, -1 = left
    float speedMulti = 1;

    public Animator anim;

    List<Collider2D> ObjectsTouchingFeet;

    public Collider2D player1Collider;
    public Collider2D player2Collider;

    private void Awake()
    {
        //Time.timeScale = (.25f);
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
        timeToJump = 0;
        timeToBoof = 0;
        playerPos = new Vector2(transform.position.x, transform.position.y);

        if(character == Character.Goon)
        {
            jumpForce = 1.55f;
            moveSpeed = 11f;
            footCollider.offset = new Vector2(0, -.86f);
        }
        if(character == Character.Boof)
        {
            jumpForce = 1.4f;
            moveSpeed = 12.5f;
            footCollider.offset = new Vector2(0, -.78f);
        }
        jumpForce *= 732;
    }

    private void Update() {
        playerPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
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
        rb2d.velocity = (new Vector2(moveSpeed * direction, rb2d.velocity.y));
        //rb2d.GetContacts().
        //Debug.Log(playerNo + ", " + ObjectsTouchingFeet.ToArray().ToString());
        if ((Input.GetAxis("P1.Jump") > 0)&&playerNo==1&&ObjectsTouchingFeet.ToArray().Length>0 && timeToJump <= 0) {
            Jump();
        }
        if ((Input.GetAxis("P2.Jump") > 0) && playerNo == 2 && ObjectsTouchingFeet.ToArray().Length > 0 && timeToJump <= 0)
        {
            Jump();
        }
        if (playerNo == 1 ? (Input.GetAxis("P1.Fall") > 0) : (Input.GetAxis("P2.Fall") > 0))
            rb2d.gravityScale = 4;
        else
            rb2d.gravityScale = 1;
        /*foreach (Collider2D c in ObjectsTouchingFeet)
            Debug.Log(gameObject.name + ": " + c.name);*/
        if (/*collision.gameObject.tag == "Wall"*/(/*Physics2D.Raycast(playerPos + new Vector2(direction, 0) * .5f, new Vector2(direction, 0)).collider.name*/ Physics2D.Raycast(playerPos+ new Vector2(direction, 0)*1.5f/2, new Vector2(direction, 0)).distance <= .1)&&timeToBoof<=0)
        {
            //Debug.Log(playerNo + "" + playerPos + "" + Physics2D.Raycast(playerPos, new Vector2(direction, 0)).point);
            //Debug.DrawRay(playerPos, new Vector2(direction, 0), Color.red, .5f);
            //Debug.Log(Physics2D.Raycast(playerPos + new Vector2(direction, 0) * .5f, new Vector2(direction, 0)).collider.name);
            if (Physics2D.Raycast(playerPos + new Vector2(direction, 0) * .5f, new Vector2(direction, 0)).collider == (playerNo == 1 ? player1Collider : player2Collider))
                return;
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
        timeToBoof = .35f;  
    }

    void Jump()
    {
        Debug.Log("In the jump mehtod");
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpForce);
        timeToJump = .5f;
        if (anim != null)
            anim.SetBool("Jump", true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ObjectsTouchingFeet.Add(collision);
        
        if (collision.gameObject.tag == "Player" && Physics2D.Raycast(playerPos, new Vector2(0, 1)).distance <= .75) {
            Debug.Log(playerNo + " HIT SOMEONE AT: " + collision.transform.position.x + "," + collision.transform.position.y);
            Debug.DrawRay(playerPos, new Vector2(direction, 0), Color.cyan, .5f);
            Win(playerNo);
        }
        if (collision.gameObject.tag != "Player" && Physics2D.Raycast(playerPos, new Vector2(0, -1)).distance <= .75)
        {
            ObjectsTouchingFeet.Add(collision);
            if (anim != null)
                anim.SetBool("Jump", false);
            //Debug.Log("halp");
        }
        else if (collision.gameObject.tag == "Player" && timeToBoof <= 0)
        {
            SwitchDirection();
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
