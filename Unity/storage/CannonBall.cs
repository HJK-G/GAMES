using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {
    private Rigidbody2D rb;
    public float spd;
    bool go;
    float dashing;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        go = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (go==true) { rb.velocity = transform.right * spd; }
        if (dashing > 0) { dashing -= 1; GetComponent<CircleCollider2D>().enabled = false; }
        if (dashing < 1) { GetComponent<CircleCollider2D>().enabled = true; }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&go==true) { Ninja.dmg = 50; }
        if (collision.gameObject.tag=="Player" || collision.gameObject.tag == "Terrain") { go = false;
            GetComponent<Rigidbody2D>().gravityScale = 4;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name=="DetectorUp" && Ninja.delay2o2>0) { dashing = 3; }
    }
}
