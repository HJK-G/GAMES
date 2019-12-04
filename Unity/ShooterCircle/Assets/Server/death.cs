using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public int health = 10;
    bool dead = false;
   public GameObject title;

    int timer = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0 && timer < 0)
        {
            transform.position = new Vector3(100, 100, 100);
            timer = 150;
            dead = true;
        }
        if (dead)
        {
            timer--;
        }
        if (timer == 0)
        {
            timer = -1;
            health = 10;
            dead = false;
            transform.position = new Vector3(0, 0, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead)
        {
            return;
        }
        if (collision.gameObject.name == "bullet(Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            title.GetComponent<TextMesh>().text = ""+health;
        }
    }
}
