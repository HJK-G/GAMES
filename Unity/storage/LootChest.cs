using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest : MonoBehaviour {
    public GameObject slash;
    float HP;
    float Delay;
    public GameObject Emerald;
    float Emeralds;
    public Transform Chest;
    public GameObject effect;
	// Use this for initialization
	void Start () {
        HP = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (HP < 1)
        {
            GameObject Effect = Instantiate(effect, transform.position, transform.rotation); Destroy(Effect, 3.0f);
            Emeralds = Random.Range(-2f, 2f); HP = 1;
        }
        if (Emeralds > 0) { GameObject emer = Instantiate(Emerald, transform.position, transform.rotation); Emeralds -= 1; emer.GetComponent<Emeralds>().target = Chest; }
        if (Emeralds <= 0 && Emeralds > -100) { gameObject.SetActive(false); }
        Delay += 1;
        Vector3 move = new Vector3(0f, 0.025f, 0f);
        if (Delay < 40) { transform.position = transform.position + move; }
        if (Delay > 40) { transform.position = transform.position - move; }
        if (Delay > 78) { Delay = 0; }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Katana") { HP -= Ninja.atk * Ninja.mult; ; GameObject Slash = Instantiate(slash, transform.position, transform.rotation); Destroy(Slash, 0.15f); }
    }
}
