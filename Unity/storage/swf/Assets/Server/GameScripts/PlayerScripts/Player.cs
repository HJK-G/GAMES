using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public int champion;
    int roleSelect;
    int roleRotation;

    public float cd;
    public GameObject abilityIndicator;
    public float cdr;
    float spinM;
    float ability;

    private Rigidbody2D rb;
    public float speed;
    public int direction;

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
    int water;
    bool noF;
    public int pre;
    public int comDel;
    public GameObject comInd;

    public int max;
    public int slow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        choose = true;
        roleSelect = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }

        if (choose)
        {
            if (roleRotation == 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    roleRotation = 6;
                    roleSelect += 1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    roleRotation = -6;
                    roleSelect -= 1;
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
                {
                    champion = roleSelect;
                    choose = false;
                }
                if (roleSelect < 1)
                {
                    roleSelect = 6;
                }
                if (roleSelect > 6)
                {
                    roleSelect = 1;
                }
            }
            selectRole();
        }
        if (Input.GetKey(KeyCode.E))
        {
            useAbility();
        }

    }
    void useAbility()
    {
        if (cd < 1)
        {
            switch (champion)
            {
                case 1:
                    ability = 27;
                    cd = 250;
                    break;
                case 2:
                    ability = 150;
                    if (HB.GetComponent<xq>().HP < max)
                    {
                        ability += (max - HB.GetComponent<xq>().HP) * 1.43f;
                        cd = 450;
                    }
                    break;
                case 3:
                    ability = 1;
                    cd = 250;
                    break;
                case 4:
                    ability = 1;
                    cd = 250;
                    break;
                case 5:
                    ability = 28;
                    cd = 250;
                    break;
                case 6:
                    ability = 1;
                    cd = 150;
                    break;
            }
            abilityIndicator.SetActive(false);
        }
    }
    void selectRole()
    {
        switch (champion)
        {
            case 1:
                axe.SetActive(true);
                spinM = 1;
                speed = 1.2f;
                break;
            case 2:
                sword.SetActive(true);
                shield.SetActive(true);
                spinM = 1;
                speed = 1.2f;
                break;
            case 3:
                dagger.SetActive(true);
                spinM = 1.5f;
                speed = 1.44f;
                break;
            case 4:
                bow.SetActive(true);
                spinM = 0.66f;
                speed = 1.38f;
                break;
            case 5:
                pole.SetActive(true);
                hand.SetActive(true);
                spinM = 1;
                speed = 1.2f;
                break;
            case 6:
                arc.SetActive(true);
                spinM = 1;
                speed = 1.2f;
                break;
        }

        slow = 0;
    }
    void FixedUpdate()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }

        if (slow == 1)
        {
            speed = speed * 2;
        }
        if (slow > 0)
        {
            slow -= 1;
        }
        if (comDel > 0)
        {
            comDel -= 1;
            comInd.SetActive(false);
        }
        else
        {
            comInd.SetActive(true);
        }
        if (roleRotation > 0)
        {
            CSelect.transform.Rotate(Vector3.forward * -10);
            roleRotation -= 1;
        }
        else if (roleRotation < 0)
        {
            CSelect.transform.Rotate(Vector3.forward * 10);
            roleRotation += 1;
        }
        if (cdel > 0)
        {
            cdel -= 1;
        }
        if (cdel == 1)
        {
            choose = true;
            transform.position = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 0);
            CSelect.SetActive(true);
            champion = 0;
        }
        if (!choose)
        {
            CSelect.SetActive(false);
            transform.Rotate(Vector3.forward * 6 * direction * spinM);
            if (champion == 2 && HB.GetComponent<xq>().HP < max)
            {
                transform.Rotate(Vector3.forward * direction * (max - HB.GetComponent<xq>().HP) / 16.7f);
            }
        }
        if (choose)
        {
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.z = 0.0f;
            transform.rotation = Quaternion.Euler(rotty);
        }
        if (!noF)
        {
            float yaxis = Input.GetAxisRaw("Vertical") * 3;
            float xaxis = Input.GetAxisRaw("Horizontal") * 3;
            Vector2 VelocityY = rb.velocity;
            VelocityY.y = yaxis;
            rb.velocity = VelocityY;
            Vector2 VelocityX = rb.velocity;
            VelocityX.x = xaxis;
            rb.velocity = VelocityX;
        }
        if (!choose && cdel < 1)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-2121 / 1000f * speed, 2121 / 1000f * speed); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(2121 / 1000f * speed, 2121 / 1000f * speed); }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(0, 3 * speed); }
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-2121 / 1000f * speed, -2121 / 1000f * speed); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(2121 / 1000f * speed, -2121 / 1000f * speed); }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(0, -3 * speed); }
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A)) { rb.velocity = new Vector2(-3 * speed, 0); }
                if (Input.GetKey(KeyCode.D)) { rb.velocity = new Vector2(3 * speed, 0); }
            }

        }
        if (cd > 0) { cd -= 1 + cdr; } else { abilityIndicator.SetActive(true); }
        if (cleave) { GetComponent<Rigidbody2D>().angularDrag = 1f; }
        cleave = false;
        if (champion == 4) { spinM = .66F; }
        if (ability > 0)
        {
            if (champion == 1)
            {
                if (ability > 14) { transform.Rotate(Vector3.forward * -33 * direction); }
                transform.Rotate(Vector3.forward * 24 * direction); cleave = true;
            }
            if (champion == 2)
            {
                cleave = true; GetComponent<Rigidbody2D>().angularDrag = 500;
            }
            if (champion == 3) { transform.position = target.position; Instantiate(smoke, transform.position, transform.rotation); }
            if (champion == 4)
            {
                if ((int)ability == 1)
                {
                    GameObject Arrow = Instantiate(arrow, bow.GetComponent<weapon>().blade.transform.position, transform.rotation);
                    Arrow.GetComponent<arrow>().bow = bow; Arrow.GetComponent<arrow>().player = gameObject;
                    Arrow.GetComponent<arrow>().HitB = HB;
                } //spinM = 0;
            }
            if (champion == 5)
            {
                if (ability > 22) { noF = true; transform.Rotate(Vector3.forward * 6 * -direction * spinM); rb.velocity = transform.up * 20; }
                HB.SetActive(false);
                if ((int)ability == 21 && comDel > 0) { ability = 0; noF = false; return; }
                if (ability < 22 && ability > 2) { noF = false; transform.Rotate(Vector3.forward * 14 * direction); cleave = true; }
            }
            if (champion == 6)
            {
                GameObject Bolt = Instantiate(bolt, arc.GetComponent<weapon>().blade.transform.position, transform.rotation);
                GameObject Det = Instantiate(det, transform.position, transform.rotation);
                //Bolt.GetComponent<bolt>().player = gameObject;
                //Bolt.GetComponent<bolt>().HitB = HB; Bolt.GetComponent<bolt>().arc = arc;
            }
            ability -= 1;
        }
        else
        {
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.y = 0.0f;
            rotty.x = 0.0f;
            transform.rotation = Quaternion.Euler(rotty);
            HB.transform.position = transform.position;
            HB.SetActive(true);
        }
    }
}
