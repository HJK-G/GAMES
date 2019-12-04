using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = new Vector3(0f, 0f, -0.5f);
        transform.position = player.position + offset;
	}
}
