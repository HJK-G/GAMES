using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlot : MonoBehaviour {
    public float item;
    public Sprite Longsword;
    public Sprite Claymore;
    public Sprite Stinger;
    public float sNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.J) && sNum==1) { Ninja.item = item; }
        if (Input.GetKeyDown(KeyCode.K) && sNum == 2) { Ninja.item = item; }
        if (Input.GetKeyDown(KeyCode.L) && sNum == 3) { Ninja.item = item; }
        if (Input.GetKeyDown(KeyCode.Semicolon) && sNum == 4) { Ninja.item = item; }
        if (Shop.slot==sNum) { item = Shop.item;}
        if (item == 1) { GetComponent<SpriteRenderer>().sprite = Longsword; }
        if (item == 2) { GetComponent<SpriteRenderer>().sprite = Claymore; }
        if (item==3) { GetComponent<SpriteRenderer>().sprite = Stinger; }
	}
}
