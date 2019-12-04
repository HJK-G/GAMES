using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public float spd;
    float rot=90;
    public Transform dir;
    public GameObject effect;
    public static float active;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 off = new Vector3(0f, 1000f, 0f);
      if (active<1) { transform.position = dir.position; }
        if (active>0) { transform.position = off; active -= 1; }
        transform.Rotate(Vector3.up * spd);
        rot += 1;
        if (rot>179) { rot = 0;GameObject Effect = Instantiate(effect, transform.position, dir.rotation); Destroy(Effect, 1f); }
	}
}
