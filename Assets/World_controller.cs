using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_controller : MonoBehaviour {
    //declared variables
    public int world                    = 2;
    private bool switching_worlds       = false;

    //undeclared variables
    private GameObject[] world_1_assets;
    private GameObject[] world_2_assets;

    // Use this for initialization
    void Start() {
        //call function to get me the array of all objects in the worlds
        world_1_assets          = get_world_assets("world_1");
        world_2_assets          = get_world_assets("world_2");

        //call toggle for the first time to make sure only one world is showing (this could be done in a much cleaner way)
        switch_worlds(false, true);

        world = 1;
    }

    // Update is called once per frame
    void Update() {
        //check if the player is switching, and if he is, switch worlds
        update_switch();
        if (switching_worlds) {
            toggle_worlds();
        }
    }

    void FixedUpdate() {
        
    }

    //function to check for switch keypress
    void update_switch() {
        switching_worlds = Input.GetKeyDown(KeyCode.E);
    }

    //returns game object with specific tags
    private GameObject[] get_world_assets(string which) {
        return GameObject.FindGameObjectsWithTag(which);
    }

    //loops through all assets in the chosen world and sets either true or false
    void switch_world(GameObject[] all_world_assets, bool status) {
        foreach(GameObject individual_asset in all_world_assets) {
            individual_asset.SetActive(status);
        }
    }


    //detect which world is currently active and switch the world based on that
    void toggle_worlds() {
        if(world == 1) {
            world = 2;
            switch_worlds(true, false);
        } else if (world == 2) {
            world = 1;
            switch_worlds(false, true);
        }
    }

    //function to take in and switch which world is active (OR set both)
    //take the arguement of:
    //BOOL: world 1 status (active or inactive)
    //BOOL: world 2 status (active or inactive)
    void switch_worlds(bool world_1_status, bool world_2_status) {
        switch_world(world_2_assets, world_1_status);
        switch_world(world_1_assets, world_2_status);
    }
}
