using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour
{
    float timer;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <60) { timer += 1 * Time.deltaTime; }
        else
        {
            transform.position += new Vector3(x,y,0);
        }
    }
}
