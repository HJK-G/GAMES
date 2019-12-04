using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    int chg;
    public int cvr;
    public BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.forward * 90);
    }

    // Update is called once per frame
    private void Update()
    {
    }
    void FixedUpdate()
    {
        chg += 1;
        if (chg>24) { transform.localScale = new Vector3(2.5f,0.5f,1);col.enabled = true; }
        if (chg>26) { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
    }
}

