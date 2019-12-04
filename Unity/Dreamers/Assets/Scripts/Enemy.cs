using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;
    public string desc;
    public float health;
    public int spd;
    public Rigidbody2D rb;

    public float damage;
    public int attackDelay;
    public int timer;
    public int range;

    public int type;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        AI();
    }

    public void AI()
    {
        switch (type)
        {
            case 0:
                Vector3 movement = Player.self.transform.position - transform.position;
                if (movement.magnitude >= range)
                {

                }
                break;
        }
    }
}
