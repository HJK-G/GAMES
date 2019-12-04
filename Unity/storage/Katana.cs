using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour {
    public static float attack;
    public Sprite Longsword;
    public Sprite Claymore;
    public Sprite Stinger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Ninja.item == 1) { GetComponent<SpriteRenderer>().sprite = Longsword; }
        if (Ninja.item == 2) { GetComponent<SpriteRenderer>().sprite = Claymore; }
        if (Ninja.item==3) { GetComponent<SpriteRenderer>().sprite = Stinger; }
        if (attack > 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = true; attack -= 1;
        }
        if (attack <1)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Terrain") { Ninja.delay2o2 = 0; }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain") { Ninja.delay2o2 = 0; }
    }
}
