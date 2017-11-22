using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_controller : MonoBehaviour {
    //declared variables
    public int world                = 1;
    private bool switching_worlds   = false;

    //undeclared variables
    private GameObject[] world_1_assets;
    private GameObject[] world_2_assets;

    // Use this for initialization
    void Start() {

        world_1_assets = get_world_assets("world_1");
        world_2_assets = get_world_assets("world_2");
        toggle_worlds();

    }

    // Update is called once per frame
    void Update() {
        update_switch();
        if (switching_worlds) {
            toggle_worlds();
        }
    }

    void update_switch() {
        switching_worlds = Input.GetKeyDown(KeyCode.E);
    }

    //returns game object with specific tags
    private GameObject[] get_world_assets(string which) {
        return GameObject.FindGameObjectsWithTag(which);
    }

    void switch_world(GameObject[] all_world_assets, bool status) {
        foreach(GameObject individual_asset in all_world_assets) {
            individual_asset.SetActive(status);
        }
    }


    //detect whihc world is currently active and switch the world based on that
    void toggle_worlds() {
        if(world == 1) {
            world = 2;
            switch_world(world_2_assets, true);
            switch_world(world_1_assets, false);
        } else if (world == 2) {
            world = 1;
            switch_world(world_2_assets, false);
            switch_world(world_1_assets, true);
        }
    }

}
