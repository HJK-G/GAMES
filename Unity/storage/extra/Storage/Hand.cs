using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    private Rigidbody2D rb;
    public float slashSpd;
    public float slash;
    public float refresh;
    float delay1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector3 RdefRot = transform.rotation.eulerAngles;
        Vector3 LdefRot = transform.rotation.eulerAngles;
        RdefRot.z = -10.0f;
        LdefRot.z = 10.0f;
        if (Input.GetKeyDown(KeyCode.U)&&Ninja.Nrg>29) { Katana.attack = 3; slash = 5;}
        if (slash > 0) { transform.Rotate(Vector3.back * slashSpd); slash -= 1; }
        if (slash < 2 && slash > 0)
        {
            transform.Rotate(Vector3.forward * slashSpd * 5);
        }
        if (Input.GetKeyDown(KeyCode.O)) { delay1 = 12; transform.Rotate(Vector3.back * slashSpd * 2); Katana.attack = 12;
                if (Input.GetKey(KeyCode.W)) delay1 = 13; }
      
        if (delay1 > 0) { delay1 -= 1; }
        if (Ninja.delay2 > 11)
        {
            if (Input.GetKey(KeyCode.W)) {
                Vector3 UpO = transform.rotation.eulerAngles;
                UpO.z = 10.0f;
                transform.rotation = Quaternion.Euler(UpO);
            }
            if (Input.GetKey(KeyCode.S)) {
                Vector3 DownO = transform.rotation.eulerAngles;
                DownO.z = -190.0f;
                transform.rotation = Quaternion.Euler(DownO);
                delay1 = 12;
            }
            Katana.attack = 12;
        }
        if (delay1 > 0 && delay1<2) { if (Ninja.right == true) { transform.rotation = Quaternion.Euler(RdefRot); }
            if (Ninja.right == false) { transform.rotation = Quaternion.Euler(LdefRot); }
        }
    }
}

