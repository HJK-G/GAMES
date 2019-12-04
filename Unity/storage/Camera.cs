using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public Transform Ninjy;
    float calibrate;
    float delay;
    public static float Follow;
	// Use this for initialization
	void Start () {
        calibrate = 0;
        Follow = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Follow > 0) { Follow -= 1; }
        if (Follow < 1)
        {
            Vector3 offset = new Vector3(0f, 1f, -0.5f);
            if (calibrate < 1) { transform.position = Ninjy.position + offset; }
            Vector3 Oup = new Vector3(0f, 2f, -0.5f);
            Vector3 Odown = new Vector3(0f, 0f, -0.5f);
            Vector3 Oleft = new Vector3(-3f, 1f, -0.5f);
            Vector3 Oright = new Vector3(1f, 1f, -0.5f);
            if (Ninja.delay2 < 1) { calibrate = 0; }
            if (Ninja.delay2 > 0 && Ninja.delay2 < 2) { }
            if (Ninja.delay2 > 1 && Ninja.delay2 < 3) { }
            if (Ninja.delay2 > 2 && Ninja.delay2 < 4) { }
            if (Ninja.delay2 > 3 && Ninja.delay2 < 5) { transform.position = Ninjy.position + Oleft; dc(); }
            if (Ninja.delay2 > 4 && Ninja.delay2 < 6) { }
            if (Ninja.delay2 > 5 && Ninja.delay2 < 7) { }
            if (Ninja.delay2 > 6 && Ninja.delay2 < 8) { }
            if (Ninja.delay2 > 7 && Ninja.delay2 < 9) { }
        }
    }
    void dc() { calibrate = 1; }
}
