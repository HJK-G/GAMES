using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScaler : MonoBehaviour {
    Vector3 temp;
    float x;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Ninja.HP * 4 / 5;
        temp = transform.localScale;
        temp.x = Ninja.Health    / 100;
        transform.localScale = temp;
    }
}
