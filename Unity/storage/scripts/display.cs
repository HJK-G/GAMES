using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour
{
    public static int show;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (show > 0) { show -= 1; transform.position = cam.position+new Vector3(0,0,10); } else { transform.position = new Vector3(0,100,0); }
        if (Input.GetKey(KeyCode.Tab)) { show = 2; }
    }
}
