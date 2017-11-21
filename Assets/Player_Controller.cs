using UnityEngine;

public class Player_Controller : MonoBehaviour {
    //declerations
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
    }


}
