using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    int del;
    public int part;
    public GameObject healP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (del>0) { del -= 1; }
        if (part>0) { part -= 1;healP.SetActive(true); } else { healP.SetActive(false); }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (del<1) { col.gameObject.GetComponent<Player>().HB.GetComponent<xq>().HP += 1;del = 50; }
        part = 3;
    }
}
