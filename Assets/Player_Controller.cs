using UnityEngine;

public class Player_Controller : MonoBehaviour {
    //initilzation
    public int playerSpeed = 10;
    public bool facingRight = true;
    public float playerJumpPower = 1250;
    public float moveX;
    public int jumpcount = 2;
    public bool isGrounded;


    // Update is called once per frame
    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        bool testIfRunning;
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpcount < 2) {
            jumpcount++;
            Jump();
        }

        //test if running and if it is send the proper valeu to is running
        testIfRunning = moveX != 0 ? true : false;
        //GetComponent<Animator>().SetBool("isRunning", testIfRunning);
        //Animations
        //Player Direction
        if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void resetJump() {
        jumpcount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //how to check the name of what was hit. This is not useful
        //if (collision.collider.name == "Ground") {
        resetJump();
    }

    void OnTriggerEnter2D(Collider2D trig) {

    }
    //For science!
    /*//declerations
    public float playerSpeed    = 3f;
    public float jumpForce      = 1250f;

	// Use this for initialization
	void Start () {
    }
	
	//Update is called once per frame update
	void Update () {
        

    }

    //this is called once before Physics is determined (all physics calculations should be done here)
    private void FixedUpdate() {
        var moveX = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (jump()){
            moveUp();
        }
    }

    void moveUp(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
    }
    void w(string toPrint) {
        Debug.Log(toPrint);
    }

    public bool jump(){
        return Input.GetKeyDown(KeyCode.W);
    }*/


}
