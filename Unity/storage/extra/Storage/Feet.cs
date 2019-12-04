using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "EditorOnly")
        {
            Ninja.JumpCd = -2; Ninja.Dashes = 3;
        }
    }
}
