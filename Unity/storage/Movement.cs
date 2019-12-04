using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
    private Rigidbody2D rb;
    public float spd;
    public GameObject MapSavee;
    public string Dojo;
    public string Camp1;
    public string Camp2;
    public string Camp2o1;
    public string Camp3;
    public string Camp3o1;
    public string Camp4;
    public string Special1;
    public string Ambush1;
    public float away;
    float ambush;
    bool create=true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector3 update = new Vector3(MapSave.Instance.x, MapSave.Instance.y, 0f);
        transform.position = update;
    }
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate () {
            if (Input.GetKey(KeyCode.W)) { rb.velocity = transform.up * spd;}
            if (Input.GetKey(KeyCode.S)) { rb.velocity = transform.up * spd * -1; }
            if (Input.GetKey(KeyCode.A))
            { transform.Rotate(Vector3.forward * 6); }
            if (Input.GetKey(KeyCode.D)) { transform.Rotate(Vector3.forward * -6); }
        MapSave.Instance.y = transform.position.y;
        MapSave.Instance.x = transform.position.x;
        away += 1;
        if (away > 50) { ambush = Random.Range(-12f, 1f); away = 1; }
        if (ambush > 0) { SceneManager.LoadScene(Ambush1); }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Left") { ninjaImg.lookR = false; }
        if (col.gameObject.name == "Right") { ninjaImg.lookR = true; }
        if (col.gameObject.name == "Dojo") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Dojo); } }
        if (col.gameObject.name == "Camp1") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp1); } }
        if (col.gameObject.name == "Camp3") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp3); } }
        if (col.gameObject.name == "Camp2") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp2); } }
        if (col.gameObject.name == "Camp2.1") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp2o1); } }
        if (col.gameObject.name == "Camp3.1") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp3o1); } }
        if (col.gameObject.name == "Camp4") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Camp4); } }
        if (col.gameObject.name == "Special1") { if (Input.GetKey(KeyCode.Space)) { SceneManager.LoadScene(Special1); } }
        if (col.gameObject.tag == "Terrain") {away = 0; }
    }
}
