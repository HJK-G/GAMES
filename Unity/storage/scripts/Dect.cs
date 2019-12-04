using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dect : MonoBehaviour
{
    public GameObject player;
    public GameObject ind;
    public Sprite square;
    int del;
    public bool urg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        del -= 1;
        if (del<1&& GetComponent<CircleCollider2D>().radius<7) { GetComponent<CircleCollider2D>().radius += 0.5f; }
        if (GetComponent<CircleCollider2D>().radius >= 7) { player.GetComponent<Player>().target = null;
            ind.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (player.GetComponent<Player>().target != null)
        {
            Vector2 direction = player.GetComponent<Player>().target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (urg && col.gameObject != player) { player.GetComponent<Urgal>().target = col.transform; }
        if (col.gameObject!=player&&player.GetComponent<Player>().role==3) { player.GetComponent<Player>().target = col.transform;
            del = 10; GetComponent<CircleCollider2D>().radius = 0.5f; ind.GetComponent<SpriteRenderer>().sprite = square;
        }
    }
}
