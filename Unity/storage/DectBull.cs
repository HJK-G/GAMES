using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectBull : MonoBehaviour {
    private Rigidbody2D rb;
    public float spd;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = transform.up * spd;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Terrain") {Destroy(gameObject); }
    }
}
