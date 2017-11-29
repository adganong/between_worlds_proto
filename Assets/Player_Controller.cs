using UnityEngine;

public class Player_Controller : MonoBehaviour {
    //initilzation
    Rigidbody2D playersRigidbody;

    public int playerSpeed          = 10;
    public bool facingRight         = true;
    public float playerJumpPower    = 1250;
    public float fallMultiplier     = 2.5f;
    public float lowJumpMultiplier  = 2f;
    public int jumpcount            = 2;

    //control input checks 
    bool is_moving;
    bool is_jumping;


    public float moveX;
    public bool isGrounded;

    private void Awake() {
        playersRigidbody = GetComponent<Rigidbody2D> ();
    }
    // Update is called once per frame
    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        //check all inputs 
        check_inputs();
        //check if jumping, and act accordingly
        if (is_jumping && jumpcount < 1) {
            jumpcount++;
            Jump();
        }
        //move in the moveX direction (this is set when input is checked
        Move(moveX);
        //check if the direction has changed, and flip sprite if so
        CheckDirectionAndFlipSprite(moveX);
        //modifyc the gravity according to set inputs to change how the jump works 
        modify_gravity_on_jump();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        resetJump();
    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void Move(float moveValue) {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveValue * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void CheckDirectionAndFlipSprite(float moveValue) {
        if (moveValue > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (moveValue < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void resetJump() {
        jumpcount = 0;
    }

    void changeGravity(float changeBy) {
        playersRigidbody.velocity += Vector2.up * Physics2D.gravity.y * dt((changeBy - 1));
    }

    private float dt(float valueToChange) {
        return valueToChange * Time.deltaTime;
    }

    private void check_inputs() {
        is_jumping  = Input.GetButton("Jump") ? true : false;
        moveX = Input.GetAxis("Horizontal");
    }

    private void modify_gravity_on_jump () {
        if (playersRigidbody.velocity.y < 0) {
            changeGravity(fallMultiplier);
        } else if (playersRigidbody.velocity.y > 0 && !is_jumping) {
            changeGravity(lowJumpMultiplier);
        }
    }

}
