using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBolt : MonoBehaviour {
    private Rigidbody2D rb;
    public float spd;
    float start=0;
    bool grounded=false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (start < 3) { rb.velocity = transform.right * spd; start += 1; }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Terrain") { Destroy(GetComponent<Rigidbody2D>()); grounded = true; }
        if (col.gameObject.tag == "Player"&&!grounded) { Ninja.dmg = 50; }
    }
}
