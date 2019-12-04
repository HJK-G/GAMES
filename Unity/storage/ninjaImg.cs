using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ninjaImg : MonoBehaviour {
    public static bool lookR;
    Vector3 right;
    Vector3 left;
    public Transform player;
    public float away;
    public float ambush;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotty = transform.rotation.eulerAngles;
        rotty.z = 0.0f;
        transform.rotation = Quaternion.Euler(rotty);
        left = transform.localScale;
        left.x = -1/33f;
        right = transform.localScale;
        right.x = 1/33f;
        if (lookR==false)
        { transform.localScale = left;}
        if (lookR==true) { transform.localScale = right;}
        transform.position = player.position;
    }
    void FixedUpdate()
    {
        away += 1;
        if (away>25) { ambush = Random.Range(-3f, 1f); away = 1; }
        if (ambush>0) { }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag=="Terrain") { away = 0; }
    }
}
