using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject player;
    public GameObject sparks;
    public GameObject blood;
    public Transform blade;
    public GameObject HitB;
    public CapsuleCollider2D col;
    int del;
    int del2;
    public Color gold;
    public Color white;
    public GameObject upg1;
    public GameObject upg2;
    public GameObject upg3;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(HitB.GetComponent<CircleCollider2D>(), col);
    }
    void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.Space)) { transform.parent = null;transform.Rotate(Vector3.forward*20); }
        if (del > 0) { del -= 1; }
        if (del2==3) { player.GetComponent<Player>().direction = player.GetComponent<Player>().direction * -1; }
        if (del2 > 0) { del2 -= 1; }
        //if (del2==1) { player.GetComponent<Player>().dir = player.GetComponent<Player>().dir * -1; }
        if (player.GetComponent<Player>().cleave && player.GetComponent<Player>().champion == 2) { GetComponent<SpriteRenderer>().color = gold; }
        else if (!player.GetComponent<Player>().cleave && player.GetComponent<Player>().champion == 2) { GetComponent<SpriteRenderer>().color = white; }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //del2 = 5;
        if (del2 < 1 && player.GetComponent<Player>().cleave == false) {del2 = 4; }
        if (col.gameObject.tag == "Respawn"&&!col.gameObject.GetComponent<xq>().player.GetComponent<Player>().choose)
        {
            GameObject Blood = Instantiate(blood, blade.position, transform.rotation);
            col.gameObject.GetComponent<xq>().HP -= 10; del = 10;
            if (player.GetComponent<Player>().champion == 1) { HitB.GetComponent<xq>().HP += 3;
                if (player.GetComponent<Player>().cleave)
                {
                    if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().slow < 2) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().speed = col.gameObject.GetComponent<xq>().player.GetComponent<Player>().speed / 2; }
                    col.gameObject.GetComponent<xq>().player.GetComponent<Player>().slow += 100;
                }
            }
            if (player.GetComponent<Player>().champion==3) { player.GetComponent<Player>().cd -= 150; }
            if (player.GetComponent<Player>().champion==5) { player.GetComponent<Player>().comDel = 200; }
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().champion==5) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().comDel = 200; }
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().champion==6) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().cd -= 200; }
                if (col.gameObject.GetComponent<xq>().HP <= 0)
            {
                int pwrup = Random.Range(1, 4);
                if (pwrup == 1) { HitB.GetComponent<xq>().HP += 30;Instantiate(upg1, transform.position, transform.rotation); }
                if (pwrup == 2)
                {
                    player.GetComponent<Player>().speed += .12f;
                    Instantiate(upg2, transform.position, transform.rotation);
                }
                if (pwrup == 3) { player.GetComponent<Player>().cdr += .1f; Instantiate(upg3, transform.position, transform.rotation); }
                player.GetComponent<Player>().Kills = 1;
            }
        }
        else { if (del < 1) { GameObject Sparks = Instantiate(sparks, blade.position, transform.rotation); } }
    }
}
