using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg : MonoBehaviour
{
    public int damage;
    public int del;
    int dell;
    public GameObject blood;
    public bool bleed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dell<del) { dell += 1; }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (dell == del/*&&!col.gameObject.GetComponent<xq>().player.GetComponent<Player>().choose*/) { col.gameObject.GetComponent<Player>().HB.GetComponent<xq>().HP -=damage; ; dell = 0;
            if (bleed) { Instantiate(blood, transform.position, transform.rotation); } else { col.gameObject.GetComponent<Player>().HB.GetComponent<xq>().dmg = 150; }
        }
    }
}
