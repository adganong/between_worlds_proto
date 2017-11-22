using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    //to be able to grab easier
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Use this for initialization
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Guy");
    }

    // LateUpdate is called once at the end of each frame
    void LateUpdate() {
        //grab thye x and y positions of the player
        float xPos = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float yPos = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(xPos, yPos, gameObject.transform.position.z);
    }
}
