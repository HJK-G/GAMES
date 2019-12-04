using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public GameObject MapSavee;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E)) { MapSave.Instance.EOne += 1; }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name=="Emerald(Clone)") { Destroy(col.gameObject); MapSave.Instance.EOne += 1; }
    }
}
