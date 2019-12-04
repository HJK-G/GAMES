using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePortal : MonoBehaviour {
    public Transform dir;
    public GameObject effect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 1/2);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Ninja") {if(Input.GetKeyDown(KeyCode.Space)) { GameObject Effect = Instantiate(effect, transform.position, dir.rotation); Destroy(Effect, 1f); gameObject.SetActive(false); Spawner.time = 10; } }
    }
}

