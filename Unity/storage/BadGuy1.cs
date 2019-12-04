using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy1 : MonoBehaviour {
    public Transform target;
    public float lungeCd;
    public float lungePwr;
    private Rigidbody2D rb;
    private CircleCollider2D col;
    public GameObject effect;
    public GameObject warning;
    public Transform img;
    public GameObject slash;
    float xaxis;
    float active;
    float dashing;
    float HP=60;
    float Emeralds=-100;
    public GameObject Leaping;
    float leapDel=0;
    public GameObject Emerald;
    public Transform Chest;
    float Hold;
	// Use this for initialization
	void Start () {
        lungeCd = 150;
        rb = GetComponent<Rigidbody2D>();
        active = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (HP<1) { GameObject Effect = Instantiate(effect, transform.position, transform.rotation); Destroy(Effect, 3.0f);
            Emeralds = Random.Range(-3f,1f); HP = 1;   }
        if (Emeralds > 0) { GameObject emer = Instantiate(Emerald, transform.position, transform.rotation); Emeralds -= 1; emer.GetComponent<Emeralds>().target = Chest; }
        if (Emeralds <= 0 && Emeralds > -100) { gameObject.SetActive(false); }
        if (active > 0)
        {
            if (lungeCd > 91 || lungeCd < 49) { lungeCd -= Random.Range(-1f, 3f); } else { lungeCd -= 1; }
            if (lungeCd < 1)
            {
                lungeCd = 250;
            }
            if (lungeCd < 10)
            {
                xaxis = Input.GetAxisRaw("Horizontal");

                Vector2 VelocityX = rb.velocity;
                VelocityX.x = xaxis;
                rb.velocity = VelocityX;
            }
            if (lungeCd < 51 && lungeCd > 49) { rb.velocity = transform.right * lungePwr; }
            if (lungeCd < 71 && lungeCd > 69) { rb.velocity = transform.right * lungePwr; }
            if (lungeCd<70&&lungeCd>10) { leapDel -= 1; if (leapDel < 1) { GameObject leaping = Instantiate(Leaping, transform.position, transform.rotation); Destroy(leaping, 1.0f); leapDel = 3; } }
            if (lungeCd < 91 && lungeCd > 89) {
                GameObject Warning = Instantiate(warning, img.position, img.rotation);
                Destroy(Warning, 1.0f);
            }
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);
            active-= 1;
            if(dashing>0) { dashing -= 1; GetComponent<CircleCollider2D>().enabled = false; }
            if (dashing<1) { GetComponent<CircleCollider2D>().enabled = true; }
            if (Hold>0) { Hold -= 1; gameObject.layer = 0; }
            if (Hold <1) {gameObject.layer = 8; }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") { if (lungeCd < 70 && lungeCd > 10) { Ninja.dmg = 50; } }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.name == "Katana") { HP -= Ninja.atk * Ninja.mult; ; GameObject Slash = Instantiate(slash, transform.position, transform.rotation); Destroy(Slash,0.15f); }
        if (col.gameObject.name=="DetectorBullet(Clone)") { active = 25; }
        if (col.gameObject.name=="DetectorUp"&&Ninja.delay2o2>0) { dashing = 3; }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DetectorUp" && Ninja.delay2o2 > 0) { dashing = 3; }
        if (collision.gameObject.name=="Hold") { Hold = 3; }
    }
}
