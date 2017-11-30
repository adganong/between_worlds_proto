using UnityEngine;

public class Player_Controller : MonoBehaviour {
    //initilzation
    Rigidbody2D playersRigidbody;

    public float playerSpeed        = 10f;
    public bool facingRight         = true;
    public float playerJumpPower    = 1250;
    public float fallMultiplier     = 2.5f;
    public float lowJumpMultiplier  = 2f;
    public int jumpcount            = 2;

    public float friction           = 0.5f; //dunno how to use this

    public float acceleration       = 1.1f;
    public float speed_min          = 6f;
    public float speed_max          = 10f;

    //control input checks 
    bool is_moving;
    bool is_jumping;
    bool is_visceral;


    public float moveX;
    public bool isGrounded;

    private void Awake() {
        playerSpeed = speed_min;
        playersRigidbody = GetComponent<Rigidbody2D> ();
    }
    // Update is called once per frame
    void Update() {
        check_inputs();
        PlayerMove();
    }

    void PlayerMove() {
        //check all inputs 
        if (!is_visceral) {
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
        } else if (is_visceral) {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        resetJump();
    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void Move(float moveValue) {
        if (playerSpeed < speed_max) {
            playerSpeed *= acceleration;
        } else if (moveValue == 0) {
            playerSpeed = speed_min;
        }
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
        check_for_visceral();
    }

    private void modify_gravity_on_jump () {
        if (playersRigidbody.velocity.y < 0) {
            changeGravity(fallMultiplier);
        } else if (playersRigidbody.velocity.y > 0 && !is_jumping) {
            changeGravity(lowJumpMultiplier);
        }
    }

    private void check_for_visceral() {
        if (Input.GetKeyDown(KeyCode.W) && !is_visceral) {
            Debug.Log("It has been pressed");
            is_visceral = true;
        } else if (Input.GetKeyDown(KeyCode.W) && is_visceral) {
            Debug.Log("It has been pressed");
            is_visceral = false;
        }
    }

}
