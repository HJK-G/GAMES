using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeralds : MonoBehaviour {
    float Jump = 150;
    private Rigidbody2D rb;
    float xaxis;
    bool collect;
    public Transform target;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        collect = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rotty = transform.rotation.eulerAngles;
        rotty.z = 0.0f;
        transform.rotation = Quaternion.Euler(rotty);
        xaxis = Input.GetAxisRaw("Horizontal");

        Vector2 VelocityX = rb.velocity;
        VelocityX.x = xaxis;
        rb.velocity = VelocityX;
        if (Jump > 0) { Jump -= 1;}
        if (Jump < 2 && Jump > 0) { rb.velocity = transform.up * 10; }
        if (collect==true)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.velocity = transform.right * 40;
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ninja")
        {
            collect = true;
        }
        if (col.gameObject.name=="Chest") { gameObject.SetActive(false); Display.Emeralds += 1; }
            Jump = 80;
    }
}
