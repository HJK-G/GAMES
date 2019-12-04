using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    float delay;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (delay>0) { delay -= 1; }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "Ninja"&& delay<1) { Ninja.dmg = 80; delay = 25; }
    }
}
