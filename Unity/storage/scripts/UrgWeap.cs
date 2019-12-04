using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrgWeap : MonoBehaviour
{
    public GameObject Urgal;
    public GameObject sparks;
    public GameObject blood;
    public Transform blade;
    public GameObject HitBU;
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
        Physics2D.IgnoreCollision(HitBU.GetComponent<CircleCollider2D>(), col);
    }
    void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (del > 0) { del -= 1; }
        if (del2 > 0) { del2 -= 1; }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //del2 = 5;
        Urgal.GetComponent<Urgal>().dir = Urgal.GetComponent<Urgal>().dir * -1; del2 = 0;
        if (col.gameObject.tag == "Respawn")
        {
            GameObject Blood = Instantiate(blood, blade.position, transform.rotation);
            col.gameObject.GetComponent<xq>().HP -= 10; del = 10;
            if (col.gameObject.GetComponent<xq>().HP <= 0)
            {
                if (Cameraa.track) { Cameraa.slow = 120; Time.timeScale = 0.4f; } else { display.show = 50; }
            }
        }
        else { if (del < 1) { GameObject Sparks = Instantiate(sparks, blade.position, transform.rotation); Cameraa.zoom = 3; } }
    }
}
