using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadguyHP : MonoBehaviour {
    Vector3 temp;
    public float max;
    public float HP;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale;
        temp.x = HP / max;
        transform.localScale = temp;
    }
}
