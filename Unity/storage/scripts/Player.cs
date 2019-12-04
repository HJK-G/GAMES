using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public int player;
    public float spd;
    public int dir;

    public int role;
    public float cd;
    public GameObject abilInd;
    public float cdr;
    float spinM;
    float ability;
    public bool choose;
    public GameObject axe;
    public GameObject sword;
    public GameObject shield;
    public GameObject dagger;
    public GameObject bow;
    public GameObject pole;
    public GameObject hand;
    public GameObject arc;

    public bool cleave;
    public Transform target;
    public GameObject arrow;
    public GameObject bolt;
    public GameObject det;
    public int Kills;
    public GameObject smoke;

    public GameObject HB;
    public int cdel;
    public GameObject CSelect;
    int roleS;
    int rot;
    int water;
    bool noF;
    public int pre;
    public int comDel;
    public GameObject comInd;

    public int max;
    public int slow;

    public bool ffa;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        choose = true;
        roleS = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == 1)
        {
            if (choose)
            {
                if (rot == 0)
                {
                    if (Input.GetKey(KeyCode.A)) { rot = 6; roleS += 1; }
                    if (Input.GetKey(KeyCode.D)) { rot = -6; roleS -= 1; }
                    if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.W)) { role = roleS; choose = false; }
                    if (roleS<1) { roleS = 6; }
                    if (roleS > 6) { roleS = 1; }
                }
                roleV();
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                abilities();
            } 
        }
        if (player == 2)
        {
            if (choose)
            {
                if (rot == 0)
                {
                    if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.K)) { rot = 6; roleS += 1; }
                    if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.Semicolon)) { rot = -6; roleS -= 1; }
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) { role = roleS; choose = false; }
                    if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.L)) { role = roleS; choose = false; }
                    if (roleS < 1) { roleS = 6; }
                    if (roleS > 6) { roleS = 1; }
                }
                roleV();
            }
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                abilities();
            }
            if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.L))
            {
                abilities();
            }
        }
        if (player == 3)
        {
            if (choose)
            {
                if (rot == 0)
                {
                    if (Input.GetKey(KeyCode.F)) { rot = 6; roleS += 1; }
                    if (Input.GetKey(KeyCode.H)) { rot = -6; roleS -= 1; }
                    if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.T)) { role = roleS; choose = false; }
                    if (roleS < 1) { roleS = 6; }
                    if (roleS > 6) { roleS = 1; }
                }
                roleV();
            }
            if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.G))
            {
                abilities();
            }
        }
        if (player == 4)
        {
            if (choose)
            {
                if (rot == 0)
                {
                    if (Input.GetKey(KeyCode.J)) { rot = 6; roleS += 1; }
                    if (Input.GetKey(KeyCode.L)) { rot = -6; roleS -= 1; }
                    if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.I)) { role = roleS; choose = false; }
                    if (roleS < 1) { roleS = 6; }
                    if (roleS > 6) { roleS = 1; }
                    roleV();
                }
            }
            if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.K))
            {
                abilities();
            }
        }
    }
    void abilities()
    {
        if (cd < 1)
        {
            if (role == 1) { ability = 27; cd = 250; }
            if (role == 2) { ability = 150; if (HB.GetComponent<xq>().HP < max) { ability += (max - HB.GetComponent<xq>().HP) * 1.43f; }; cd = 450; }
            if (role == 3) { ability = 1; cd = 250; }
            if (role == 4) { ability = 1; cd = 25;}
            if (role == 5) { ability = 28; cd = 250; }
            if (role == 6) { ability = 1; cd = 150; }
            abilInd.SetActive(false);
        }
    }
    void roleV()
    {
        if (role == 1) { axe.SetActive(true); spinM = 1; spd = 1.2f; }
        if (role == 2) { sword.SetActive(true); shield.SetActive(true); spinM = 1; spd = 1.2f; }
        if (role == 3) { dagger.SetActive(true); spinM = 1.5f; spd = 1.44f; }
        if (role == 4) { bow.SetActive(true); spinM = 0.66f; spd = 1.38f; }
        if (role == 5) { pole.SetActive(true); hand.SetActive(true); spinM = 1; spd = 1.2f; }
        if (role == 6) { arc.SetActive(true); spinM = 1; spd = 1.2f; }
        slow = 0;
    }
    void FixedUpdate()
    {
        if (slow == 1) { spd = spd *2; }
        if (slow>0) { slow -= 1; }
        if (comDel>0) { comDel -= 1; comInd.SetActive(false); } else { comInd.SetActive(true); }
        if (rot > 0) { CSelect.transform.Rotate(Vector3.forward * -10); rot -= 1; }
        if (rot < 0) { CSelect.transform.Rotate(Vector3.forward * 10); rot += 1; }
        if (cdel>0) { cdel -= 1; }
        if (cdel==1) { choose = true; if (ffa) { transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3, -6), 0); }
            CSelect.SetActive(true); role = 0;
        }
        if (!choose) {CSelect.SetActive(false); transform.Rotate(Vector3.forward * 6 * dir * spinM);
            if (role == 2&& HB.GetComponent<xq>().HP< max) { transform.Rotate(Vector3.forward * dir * (max - HB.GetComponent<xq>().HP)/16.7f); }
        }
        if (choose)
        {
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.z = 0.0f;
            transform.rotation = Quaternion.Euler(rotty);
        }
        if (!noF) { float yaxis = Input.GetAxisRaw("Vertical") * 3;
            float xaxis = Input.GetAxisRaw("Horizontal") * 3;
            Vector2 VelocityY = rb.velocity;
            VelocityY.y = yaxis;
            rb.velocity = VelocityY;
            Vector2 VelocityX = rb.velocity;
            VelocityX.x = xaxis;
            rb.velocity = VelocityX; }
        if (!choose&&cdel<1) {
        if (player == 1)
        {
            if (Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-2121 / 1000f*spd, 2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(2121 / 1000f * spd, 2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(0, 3 * spd); }
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(0, -3 * spd); }
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-3 * spd, 0); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(3 * spd, 0); }
            }
        }
        if (player == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow)) { rb.velocity = new Vector2(-2121 / 1000f * spd, 2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.RightArrow)) { rb.velocity = new Vector2(2121 / 1000f * spd, 2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) { rb.velocity = new Vector2(0, 3 * spd); }
            }
            if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow)) { rb.velocity = new Vector2(-2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.RightArrow)) { rb.velocity = new Vector2(2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) { rb.velocity = new Vector2(0, -3 * spd); }
            }
            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow)) { rb.velocity = new Vector2(-3 * spd, 0); }
                if (Input.GetKey(KeyCode.RightArrow)) { rb.velocity = new Vector2(3 * spd, 0); }
            }



                if (Input.GetKey(KeyCode.O) && !Input.GetKey(KeyCode.DownArrow))
                {
                    if (Input.GetKey(KeyCode.K)) { rb.velocity = new Vector2(-2121 / 1000f * spd, 2121 / 1000f * spd); }
                    if (Input.GetKey(KeyCode.Semicolon)) { rb.velocity = new Vector2(2121 / 1000f * spd, 2121 / 1000f * spd); }
                    if (!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.Semicolon)) { rb.velocity = new Vector2(0, 3 * spd); }
                }
                if (Input.GetKey(KeyCode.L))
                {
                    if (Input.GetKey(KeyCode.K)) { rb.velocity = new Vector2(-2121 / 1000f * spd, -2121 / 1000f * spd); }
                    if (Input.GetKey(KeyCode.Semicolon)) { rb.velocity = new Vector2(2121 / 1000f * spd, -2121 / 1000f * spd); }
                    if (!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.Semicolon)) { rb.velocity = new Vector2(0, -3 * spd); }
                }
                if (!Input.GetKey(KeyCode.O) && !Input.GetKey(KeyCode.L))
                {
                    if (Input.GetKey(KeyCode.K)) { rb.velocity = new Vector2(-3 * spd, 0); }
                    if (Input.GetKey(KeyCode.Semicolon)) { rb.velocity = new Vector2(3 * spd, 0); }
                }
            }
        if (player == 3)
        {
            if (Input.GetKey(KeyCode.T) && !Input.GetKey(KeyCode.G))
            {
                if (Input.GetKey(KeyCode.F)) { rb.velocity = new Vector2(-2121 / 1000f * spd, 2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(2121 / 1000f * spd, 2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(0, 3 * spd); }
            }
            if (Input.GetKey(KeyCode.G) && !Input.GetKey(KeyCode.T))
            {
                if (Input.GetKey(KeyCode.F)) { rb.velocity = new Vector2(-2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(2121 / 1000f * spd, -2121 / 1000f * spd); }
                if (!Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(0, -3 * spd); }
            }
            if (!Input.GetKey(KeyCode.T) && !Input.GetKey(KeyCode.G))
            {
                if (Input.GetKey(KeyCode.F)) { rb.velocity = new Vector2(-3 * spd, 0); }
                if (Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(3 * spd, 0); }
            }
        }
            if (player == 4)
            {
                if (Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
                {
                    if (Input.GetKey(KeyCode.Alpha1)) { rb.velocity = new Vector2(-2121 / 1000f * spd, 2121 / 1000f * spd); }
                    if (Input.GetKey(KeyCode.Alpha3)) { rb.velocity = new Vector2(2121 / 1000f * spd, 2121 / 1000f * spd); }
                    if (!Input.GetKey(KeyCode.Alpha1) && !Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(0, 3 * spd); }
                }
                if (Input.GetKey(KeyCode.Alpha2) && !Input.GetKey(KeyCode.Alpha5))
                {
                    if (Input.GetKey(KeyCode.Alpha1)) { rb.velocity = new Vector2(-2121 / 1000f * spd, -2121 / 1000f * spd); }
                    if (Input.GetKey(KeyCode.Alpha3)) { rb.velocity = new Vector2(2121 / 1000f * spd, -2121 / 1000f * spd); }
                    if (!Input.GetKey(KeyCode.Alpha1) && !Input.GetKey(KeyCode.H)) { rb.velocity = new Vector2(0, -3 * spd); }
                }
                if (!Input.GetKey(KeyCode.Alpha5) && !Input.GetKey(KeyCode.Alpha2))
                {
                    if (Input.GetKey(KeyCode.Alpha1)) { rb.velocity = new Vector2(-3 * spd, 0); }
                    if (Input.GetKey(KeyCode.Alpha3)) { rb.velocity = new Vector2(3 * spd, 0); }
                }
            }
        }
        if (cd > 0) { cd -= 1+cdr; } else { abilInd.SetActive(true); }
        if (cleave) { GetComponent<Rigidbody2D>().angularDrag = 1f; }
        cleave = false;
        if (role==4) { spinM = .66F; }
        if (ability > 0)
        {
            if (role == 1)
            {
                if (ability > 14) { transform.Rotate(Vector3.forward * -33 * dir); }
                transform.Rotate(Vector3.forward * 24 * dir); cleave = true;
            }
            if (role == 2)
            {
                cleave = true; GetComponent<Rigidbody2D>().angularDrag = 500;
            }
            if (role == 3) { transform.position = target.position; Instantiate(smoke, transform.position, transform.rotation); }
            if (role == 4) {if (ability == 1)
                {
                    GameObject Arrow = Instantiate(arrow, bow.GetComponent<weapon>().blade.transform.position, transform.rotation);
                    Arrow.GetComponent<arrow>().bow = bow; Arrow.GetComponent<arrow>().player = gameObject;
                    Arrow.GetComponent<arrow>().HitB = HB;
                } //spinM = 0;
            }
            if (role == 5) {
                if (ability > 22) { noF = true; transform.Rotate(Vector3.forward * 6 * -dir * spinM); rb.velocity = transform.up * 20; }
                HB.SetActive(false);
                if (ability==21&&comDel>0) { ability = 0; noF = false;return; }
                if (ability<22&&ability>2) { noF = false; transform.Rotate(Vector3.forward * 14 * dir); cleave = true; }
            }
            if (role==6) {GameObject Bolt= Instantiate(bolt,arc.GetComponent<weapon>().blade.transform.position, transform.rotation);
                GameObject Det = Instantiate(det, transform.position, transform.rotation);
                Det.GetComponent<Explode>().player = gameObject;
                Det.GetComponent<Explode>().arc = arc;
                Det.GetComponent<Explode>().hb= HB;
                //Bolt.GetComponent<bolt>().player = gameObject;
                //Bolt.GetComponent<bolt>().HitB = HB; Bolt.GetComponent<bolt>().arc = arc;
            }
            ability -= 1;
        } else {
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.y = 0.0f;
            rotty.x = 0.0f;
            transform.rotation = Quaternion.Euler(rotty);
            HB.transform.position = transform.position;
            HB.SetActive(true);
        }
    }
}
