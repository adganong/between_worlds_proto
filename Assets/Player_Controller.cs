using UnityEngine;

public class Player_Controller : MonoBehaviour {

    //declare the rigid body 2d we will be using later
    private Rigidbody2D thisCharactersRigidbody;
    private float speed = 3;

	// Use this for initialization
	void Start () {
        //thisCharactersRigidbody = GameObject.GetComponent<Rigidbody2D>();
    }
	
	//Update is called once per frame update
	void Update () {
        

    }

    //this is called once before Physics is determined (all physics calculations should be done here)
    private void FixedUpdate() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

   /* //grab inputs on the keyboard and returns the float value
    private float checkForMovementInput() {
        w("Inside check for movement");
        return Input.GetAxis("Horizontal");
    }

    //takes a Vector2 and moves the character based on the values
    private void MoveCharacter(Vector2 movement) {
        w("Inside Move Character");
        thisCharactersRigidbody.AddForce(movement);
    }

    //creates and returns a vector2 based on x and y values (y not needed) and returns them
    private Vector2 createVector2For(float x, float y = 0) {
        w("Inside Create Vector 2");
        return new Vector2(x, y);
    }*/

    void w(string toPrint) {
        Debug.Log(toPrint);
    }


}
