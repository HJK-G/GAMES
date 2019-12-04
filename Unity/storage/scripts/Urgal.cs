using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urgal : MonoBehaviour
{
    private Rigidbody2D rb;
    public int player;
    public float spd;
    public int dir;

    public int role;
    public GameObject axe;
    public GameObject club;

    public Transform target;

    public GameObject HB;
    public Transform move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = move.position;
    }
    void FixedUpdate()
    {
        float yaxis = Input.GetAxisRaw("Vertical") * 3;
        float xaxis = Input.GetAxisRaw("Horizontal") * 3;
        Vector2 VelocityY = rb.velocity;
        VelocityY.y = yaxis;
        rb.velocity = VelocityY;
        Vector2 VelocityX = rb.velocity;
        VelocityX.x = xaxis;
        rb.velocity = VelocityX;
        transform.Rotate(Vector3.forward * 6 * dir);
        if (target != null)
        {
            rb.velocity = transform.up * spd;
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);
        }
    }
}
