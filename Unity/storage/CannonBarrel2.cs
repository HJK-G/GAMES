using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBarrel2 : MonoBehaviour {

    public Transform target;
    public GameObject effect;
    public GameObject slash;
    public GameObject Cball;
    float active;
    float HP = 120;
    float Emeralds = -100;
    float reload;
    public GameObject Emerald;
    public Transform Chest;
    // Use this for initialization
    void Start()
    {
        active = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP < 1)
        {
            GameObject Effect = Instantiate(effect, transform.position, transform.rotation); Destroy(Effect, 3.0f);
            Emeralds = Random.Range(-3f, 4f); HP = 1;
        }
        if (Emeralds > 0) { GameObject emer = Instantiate(Emerald, transform.position, transform.rotation); Emeralds -= 1; emer.GetComponent<Emeralds>().target = Chest; }
        if (Emeralds <= 0 && Emeralds > -100) { gameObject.SetActive(false); }
        if (active > 0)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);
            if (reload < 1) { reload = 150; shoot(); }
            if (reload < 26&&reload>24) { shoot(); }
            reload -= 1;
            active -= 1;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Katana") { HP -= Ninja.atk * Ninja.mult; ; GameObject Slash = Instantiate(slash, transform.position, transform.rotation); Destroy(Slash, 0.15f); }
        if (col.gameObject.name == "DetectorBullet(Clone)") { active = 25; }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
    }
    void shoot() { GameObject cball = Instantiate(Cball, transform.position, transform.rotation); Destroy(cball, 3.0f); cball.GetComponent<CannonBall>().spd = 40; }

}
