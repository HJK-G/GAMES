using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    float delay;
    public GameObject DectBull;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject dectBull = Instantiate(DectBull, transform.position, transform.rotation);
        transform.Rotate(Vector3.back*17);
        Destroy(dectBull, 0.4f);
    }
}
