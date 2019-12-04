using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditscam : MonoBehaviour
{
    int dell;
    public int del;
    public string home;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dell += 1;
        transform.position += new Vector3(0,-0.05f,0);
        if (del==dell) { SceneManager.LoadScene(home); }
        if (dell>del-200) { GetComponent<AudioSource>().volume = (del - dell) / 200f; }
    }
}
