using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="DetectorBullet(Clone)") {Destroy(collision.gameObject); }
    }
}
