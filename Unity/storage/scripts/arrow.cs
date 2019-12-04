using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public int del2;
    public GameObject blood;
    public GameObject sparks;
    int del;
    public GameObject HitB;
    public GameObject bow;
    public CapsuleCollider2D col;
    public GameObject player;
    public GameObject upg1;
    public GameObject upg2;
    public GameObject upg3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 20;
        //Physics2D.IgnoreCollision(HitB.GetComponent<CircleCollider2D>(), col);
        Physics2D.IgnoreCollision(bow.GetComponent<CircleCollider2D>(), col);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        del2 += 1;
        if (del2>1) { col.enabled = true; }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(GetComponent<Rigidbody2D>());
        if (col.gameObject.tag == "Respawn")
        {
            GameObject Blood = Instantiate(blood, transform.position, transform.rotation);
            col.gameObject.GetComponent<xq>().HP -= 10;/**player.GetComponent<Player>().pre; player.GetComponent<Player>().pre += 1;*/
            del = 10;
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().slow < 2) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().spd = col.gameObject.GetComponent<xq>().player.GetComponent<Player>().spd / 2; }
            col.gameObject.GetComponent<xq>().player.GetComponent<Player>().slow += 50;
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().role == 5) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().comDel = 200; }
            if (col.gameObject.GetComponent<xq>().player.GetComponent<Player>().role == 6) { col.gameObject.GetComponent<xq>().player.GetComponent<Player>().cd -= 200; }
            if (col.gameObject.GetComponent<xq>().HP <= 0) {
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
        }
        else { if (del < 1) { GameObject Sparks = Instantiate(sparks, transform.position, transform.rotation);
                player.GetComponent<Player>().pre =1;
            } }
    }
}
