using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public float emers;
    public Transform gui;
    public Transform Camera;
    public GameObject[] pages=new GameObject[3];
    bool shopping;
    int pg;
    public static float item=0;
    public static float slot;
    bool Buy;
	// Use this for initialization
	void Start () {
        shopping = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        emers = MapSave.Instance.EHund * 100 + MapSave.Instance.ETen * 10 + MapSave.Instance.EOne;
        Vector3 off = new Vector3(0f, 1000f, 0f);
        if (shopping) { gui.position = Camera.position; } else { gui.position = off; }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) { shopping = false; }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) { shopping = false; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { pg += 1; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&pg>1) { pg -= 1; }
        for(int i = 0; i < 3; i++)
        {
            pages[i].transform.position = off;
        }
        pages[pg-1].transform.position = gui.transform.position;
        if (shopping)
        {
            slot = 0;
            if (item>0) { item = 0; }
            if (Input.GetKeyDown(KeyCode.J))
            {
                slot = 1; Buy = true;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                slot = 2; Buy = true;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                slot = 3; Buy = true;
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                slot = 4; Buy = true;
            }
            if (Buy)
            {
                Buy = false;
                if (pg==1) { MapSave.Instance.cost = 40; }
                if (pg == 2) { MapSave.Instance.cost = 60; }
                if (pg == 3) { MapSave.Instance.cost = 70; }
                if (emers >= MapSave.Instance.cost) { item = pg; } else { MapSave.Instance.cost = 0; }
                shopping = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name=="Ninja" && Input.GetKey(KeyCode.Space)) { if (!shopping&&MapSave.Instance.cost==0) { shopping = true; pg = 1; } }
    }
}
