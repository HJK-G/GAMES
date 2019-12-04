using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float SpawnRate;
    public static float time;
    float count;
    public float MaxSpawns;
    public GameObject enemy;
    public Transform Ninja;
    public Transform chest;
    // Use this for initialization
    void Start () {
        count = 0;
        time = 99999;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (time < 1 && count < MaxSpawns) { time = SpawnRate*50; GameObject Enemy = Instantiate(enemy, transform.position, transform.rotation); count+= 1;
            Enemy.GetComponent<BadGuy1>().target = Ninja;
            Enemy.GetComponent<BadGuy1>().Chest = chest;
        }
        time -= 1;
	}
}
