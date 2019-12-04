using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyImg1 : MonoBehaviour {
    public Transform target;
    public float lungeCd;
    public float lungePwr;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        lungeCd = 150;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rotty = transform.rotation.eulerAngles;
        rotty.z = 0.0f;
        transform.rotation = Quaternion.Euler(rotty);
    }
}
