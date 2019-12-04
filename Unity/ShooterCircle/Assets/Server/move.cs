using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
    }
}
