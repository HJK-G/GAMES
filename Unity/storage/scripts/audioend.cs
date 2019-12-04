using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioend : MonoBehaviour
{
    public float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && Input.GetKeyDown(KeyCode.M)) { timer = time; }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer>=time) { music.play = true; Destroy(gameObject); }
    }
}
