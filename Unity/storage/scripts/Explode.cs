using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    float x;
    public float spd;
    public float life;
    float time;
    public GameObject player;
    public GameObject arc;
    public GameObject hb;
    public CapsuleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        x = 0f;
        Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(arc.GetComponent<CapsuleCollider2D>(), GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(hb.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x +=1/spd;
        transform.localScale += new Vector3(x, x, 0);
        time += 1;
        if (time>=life) { Destroy(gameObject); }
    }
}
