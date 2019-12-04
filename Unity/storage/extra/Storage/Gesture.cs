using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture : MonoBehaviour
{
    public float spd=5/200;
    float Delay;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Delay += 1;
        Vector3 move = new Vector3(0f, spd, 0f);
        if (Delay < 25) { transform.position = transform.position + move; }
        if (Delay > 25) { transform.position = transform.position - move; }
        if(Delay>48) { Delay = 0; }
    }
}