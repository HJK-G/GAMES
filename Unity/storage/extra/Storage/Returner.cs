using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Returner : MonoBehaviour {
    float test;
    public string Return;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        test += 1;
        if (test>50) { SceneManager.LoadScene(Return); }
	}
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Bandit"||collision.gameObject.name=="Emerald(Clone)") { test = 0; }
    }
}
