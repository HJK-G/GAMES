using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public CapsuleCollider2D col;
    public CapsuleCollider2D col2;
    public CapsuleCollider2D col3;
    public CapsuleCollider2D col4;
    public CapsuleCollider2D col5;
    public CapsuleCollider2D col6;
    public CapsuleCollider2D col7;
    public GameObject Ninja;
    public float disable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (disable>0) { disable -= 1; Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col2); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col3); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col4); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col5); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col6); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col7); }
        if (disable<1) { Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col2, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col3, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col4, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col5, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col6, false); Physics2D.IgnoreCollision(Ninja.GetComponent<CircleCollider2D>(), col7, false); }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Ninja") {if (Input.GetKeyDown(KeyCode.S)) { disable = 30; } }
    }

}
