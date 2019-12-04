using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFlip : MonoBehaviour {
    public float delay;
	// Use this for initialization
	void Start () {
        delay = -20;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (delay>0) { delay -= 1; }
		if (delay>-1&&delay<1 ) { delay=-11; }
        if (delay<-1&&delay>-12) { transform.Rotate(Vector3.forward * -18);delay += 1; }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name=="Ninja"&&delay<-19) { delay = 50; }
    }
}
