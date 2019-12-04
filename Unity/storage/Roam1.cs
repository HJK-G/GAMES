using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam1 : MonoBehaviour {
    float time;
    float dir;
    float face;
    public float spd;
    public Sprite Front;
    public Sprite Back;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 lr = new Vector3(spd, 0f, 0f);
        time -= Random.Range(0f, 2f);
        if (time<1) { time = 100; dir = Random.Range(-1f,1f); face = -1; }
        if (dir>0) { transform.position = transform.position + lr; }
        if (dir<0) { transform.position = transform.position - lr; }
        if (face<0) { GetComponent<SpriteRenderer>().sprite = Back; }
        if (transform.position.x>64) { dir = -1; }
        if (transform.position.x < 45) { dir = 1; }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Ninja") { GetComponent<SpriteRenderer>().sprite = Front;dir = 0; time = 50;face = 0; }
    }
}
