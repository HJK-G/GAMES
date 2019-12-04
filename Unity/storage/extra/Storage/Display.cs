using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour {
    public Transform Ninja;
    public static float Emeralds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = new Vector3(0f, 0f, 0f);
        transform.position = Ninja.position + offset;
	}
}
