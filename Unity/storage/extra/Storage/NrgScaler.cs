using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrgScaler : MonoBehaviour {
    Vector3 temp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        temp = transform.localScale;
        temp.x = Ninja.Nrg / 1000f;
        transform.localScale = temp;
    }
}
