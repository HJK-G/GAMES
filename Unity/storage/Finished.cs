using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour {
    public static float finished=6000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        finished -= 1;
	}
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { finished = 150; }
    }
}
