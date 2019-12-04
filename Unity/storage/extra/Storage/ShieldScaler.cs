using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScaler : MonoBehaviour {
    Vector3 temp;
    public float x;
    public float deb;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deb = Ninja.Shield;
        x = Ninja.HP * 1 / 5;
        temp = transform.localScale;
        temp.x = Ninja.Shield / x;
        transform.localScale = temp;
        if (Ninja.Shield < x) { Ninja.Shield += x * 1 / 1200; }
    }
}
