using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScaler : MonoBehaviour
{
    Vector3 temp;
    public GameObject HitB;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HitB.GetComponent<xq>().HP>x) { x = HitB.GetComponent<xq>().HP; }
        if (HitB.GetComponent<xq>().HP<=0) { x = 50; }
        temp = transform.localScale;
        temp.x = HitB.GetComponent<xq>().HP / x;
        transform.localScale = temp;
    }
}
