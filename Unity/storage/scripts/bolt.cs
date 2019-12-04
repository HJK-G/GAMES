using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt : MonoBehaviour
{
    private Rigidbody2D rb;
    public int del2;
    public GameObject exp;
    public GameObject hit;
    int del;
    public GameObject HitB;
    public GameObject player;
    public CapsuleCollider2D col;
    public GameObject arc;
    public GameObject upg1;
    public GameObject upg2;
    public GameObject upg3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 60;
        Physics2D.IgnoreCollision(arc.GetComponent<CircleCollider2D>(), col);
        //col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        del2 += 1;
        if (del2>2) { col.enabled=true; }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Respawn")
        {
            col.gameObject.GetComponent<xq>().HP -= 10;/**player.GetComponent<Player>().pre; player.GetComponent<Player>().pre += 1;*/
            del = 10;
            Instantiate(hit, transform.position, transform.rotation);
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().role == 5) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().comDel = 250; }
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().role == 6) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().cd -= 200; }
            if (col.gameObject.GetComponent<xq>().HP <= 0)
            {
                if (Cameraa.track) { Cameraa.slow = 100; Time.timeScale = 0.3f; } else { display.show = 50; }
                int pwrup = Random.Range(1, 4);
                if (pwrup == 1) { HitB.GetComponent<xq>().HP += 30; Instantiate(upg1, transform.position, transform.rotation); }
                if (pwrup == 2)
                {
                    player.GetComponent<Player>().spd += .12f;
                    Instantiate(upg2, transform.position, transform.rotation);
                }
                if (pwrup == 3) { player.GetComponent<Player>().cdr += .1f; Instantiate(upg3, transform.position, transform.rotation); }
                player.GetComponent<Player>().Kills = 1;
            }
        } Instantiate(exp,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
