using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name=="MapEdge") { Camera.Follow = 3; }
    }
}
