using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerRand : MonoBehaviour
{
    public float xRange;
    public float yRange;
    public int disable;
    public float scale;
    public bool rand;
    public bool nothere;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
        transform.Rotate(Vector3.forward * Random.Range(0, 360));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)&&Input.GetKey(KeyCode.Tab)) { rand = true; }
    }
    void FixedUpdate()
    {
        if (rand)
        {
            transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
            transform.Rotate(Vector3.forward * Random.Range(0, 360));
            rand = false;
        }
        if (disable > Cameraa.map) { transform.localScale = new Vector3(0, 0, 0); }
        //else { if (scale != 0) { transform.localScale = new Vector3(scale, scale, 0); } else { transform.localScale = new Vector3(1, 1, 0); } }
    }
}
