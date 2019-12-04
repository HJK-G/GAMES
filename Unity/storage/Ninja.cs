using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ninja : MonoBehaviour {
    private Rigidbody2D rb;
    float spd;
    float xaxis;
    float yaxis;
    public static bool right = true;
    float calibrate;
    float cdO = 0;
    float delay1;
    public static float delay2;
    public static float delay2o2;
    bool smash;
    Vector3 temp;
    Vector3 left;
    public static float dmg;
    float x;
    public static float Shield=200;
    public static float Health=800;
    public static float HP = 1000;
    public static float Nrg=1000;
    float ECons = 100;
    public static float JumpCd=0;
    public static float Dashes;
    public GameObject BadGuy;
    public GameObject Cannon1;
    public string MapScene;
    public static float mult;
    public static float atk = 20;
    float platform;
    public float test;
    public static float item;
    // Use this for initialization
    void Start()
    {
        Vector3 restart = new Vector3(-14f, -4f, 0f);
        rb = GetComponent<Rigidbody2D>();
        calibrate = 0;
        delay2 = 0;
        spd = 500;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        test = item;
        if (item == 1) { atk = 25; ECons = 120; }
        if (item == 2) { atk = 30; ECons = 120; }
        if (item==3) { atk = 15;ECons = 50; }
        if (dmg>0)
        {
            if (Shield>dmg) { Shield -= dmg; }
            if (Shield<dmg) { x = dmg - Shield; Health -= x; Shield = 0; }
            dmg = 0;
        }
        if (Nrg < 1000) { Nrg += 1; }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.R)) {Vector3 restart = new Vector3(-14f, -4f, 0f); transform.position = restart; }
        if (calibrate > 0) { calibrate -= 1; }
        xaxis = Input.GetAxisRaw("Horizontal") * spd;

        Vector2 VelocityX = rb.velocity;
        VelocityX.x = xaxis;
        rb.velocity = VelocityX;
        Vector2 Right = new Vector2(spd, 0);
        Vector2 Left = new Vector2(-spd, 0);
        temp = transform.localScale;
        temp.x = 3 / 5f;
        left = transform.localScale;
        left.x = -3 / 5f;
        if (Input.GetKeyDown(KeyCode.W) && JumpCd<1) {rb.velocity=transform.up*20; JumpCd += 1; }
        if (Input.GetKey(KeyCode.D)) { right = true; transform.localScale = temp; rb.AddForce(Right); }
        if (Input.GetKey(KeyCode.A)) { right = false; transform.localScale = left; rb.AddForce(Left); }
        if (calibrate < 1)
        {
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.z = 0.0f;
            transform.rotation = Quaternion.Euler(rotty);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.U))
        {
            if (right == true)
            {
                calibrate = 10;
                Vector3 rotty = transform.rotation.eulerAngles;
                rotty.z = -70.0f;
                transform.rotation = Quaternion.Euler(rotty);
            }
            if (right == false)
            {
                calibrate = 10;
                Vector3 rotty = transform.rotation.eulerAngles;
                rotty.z = 70.0f;
                transform.rotation = Quaternion.Euler(rotty);
            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.U))
        {
            if (right == true)
            {
                calibrate = 10;
                Vector3 rotty = transform.rotation.eulerAngles;
                rotty.z = 90.0f;
                transform.rotation = Quaternion.Euler(rotty);
            }
            if (right == false)
            {
                calibrate = 10;
                Vector3 rotty = transform.rotation.eulerAngles;
                rotty.z = -90.0f;
                transform.rotation = Quaternion.Euler(rotty);
            }
        }
        if (Input.GetKeyDown(KeyCode.U)) { Nrg -= ECons/5; }
        if (Input.GetKey(KeyCode.I)&&delay1<2) {if (Nrg > 99)
            {
                calibrate = 19;
                delay1 = 19;
                Nrg -= ECons;
                Katana.attack = 19;
            }
        }
        if (delay1 > 1)
        {
            if (right == true) { transform.Rotate(Vector3.back * 40); }
            if (right == false) { transform.Rotate(Vector3.forward * 40); }
            delay1 -= 1;
        }
        if (Nrg > 99 && Dashes>0)
        {
            Vector3 rotWD = transform.rotation.eulerAngles;
            Vector3 rotWA = transform.rotation.eulerAngles;
            Vector3 rotRUp = transform.rotation.eulerAngles;
            Vector3 rotLUp = transform.rotation.eulerAngles;
            rotWD.z = 45.0f;
            rotWA.z = -45.0f;
            rotRUp.z = 90f;
            rotLUp.z = -90f;
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 1; diag(); transform.rotation = Quaternion.Euler(rotWD); } }
                if (Input.GetKey(KeyCode.A)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 5; diag(); transform.rotation = Quaternion.Euler(rotWA); } }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { if (Input.GetKeyDown(KeyCode.O)) { diag(); calibrate = 10; if (right == true) { transform.rotation = Quaternion.Euler(rotRUp); delay2 = 2; } if (right == false) { transform.rotation = Quaternion.Euler(rotLUp); delay2 = 8; } } }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 3; diag(); transform.rotation = Quaternion.Euler(rotWA); } }
                if (Input.GetKey(KeyCode.A)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 6; diag(); transform.rotation = Quaternion.Euler(rotWD); } }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 12; testy();} }
            }
            if (Input.GetKey(KeyCode.D)) { if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 4; testy(); } } }
            if (Input.GetKey(KeyCode.A)) { if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) { if (Input.GetKeyDown(KeyCode.O)) { delay2 = 7; testy(); } } }
        }
        if (delay2o2 > -1 && delay2<12)
        {
            yaxis = Input.GetAxisRaw("Vertical") * spd;

            Vector2 VelocityY = rb.velocity;
            VelocityY.y = yaxis;
            rb.velocity = VelocityY;
            delay2o2 -= 1;
        }
        Vector2 Smash = new Vector2(0, -1200);
        if (delay2o2 > 0) {
            if (delay2 > 8) { rb.AddForce(Smash); }
            if (delay2 > 0 && delay2 < 5) { rb.velocity = transform.right * 70; }
            if (delay2 > 4 && delay2 < 9) { rb.velocity = transform.right * -70; }
        }
        if (delay2>11) { smash = true; mult = 3; } else { mult = 1; }
        if (smash==true && JumpCd<-1)
        {
            yaxis = Input.GetAxisRaw("Vertical") * spd;
            Vector2 VelocityY = rb.velocity;
            VelocityY.y = yaxis;
            rb.velocity = VelocityY;
            delay2o2 -= 1;
            smash = false;
        }
        if (delay2o2<0) { delay2 = 0;}
        if (cdO > 0) { cdO -= 1; }
    }
    public void testy() { delay2o2 = 8; cdO = 1; Nrg -= ECons; Dashes -= 1;}
    public void diag() { delay2o2 = 8; cdO = 1; calibrate = 7; Nrg -= ECons; Dashes -= 1; }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name=="Gate" || col.gameObject.name == "Camp1") {if (Input.GetKeyDown(KeyCode.Space)) { SceneManager.LoadScene(MapScene);} }
        if (col.gameObject.name == "RightEnter") { if (Input.GetKeyDown(KeyCode.Space)) { Vector2 Interior = new Vector2(205.4f,-6.5f); transform.position = Interior; } }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag=="Platform") {if (Input.GetKeyDown(KeyCode.S)) { gameObject.layer = 9; } }
    }
}

