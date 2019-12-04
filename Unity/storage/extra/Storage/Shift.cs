using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour {
    public float ud;
    public float lr;
    float duration;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 up = new Vector3(0f, ud, 0f);
        Vector3 right = new Vector3(lr, 0f, 0f);
        if (Finished.finished<1) { Debug.Log("Move",gameObject); transform.position = transform.position + right; }
    }
}
