using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xq : MonoBehaviour
{
    public float HP;
    public int regDel;
    public GameObject player;
    public int del;
    bool spawn;
    public bool urg;
    int heal;
    public GameObject death;
    public GameObject score;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (del > 0) { del -= 1; HP = 50; }
        if (!urg&&Input.GetKey(KeyCode.Tab))
        {
            if (player.GetComponent<Player>().player == 3 && Input.GetKeyDown(KeyCode.Alpha3)) { if (!spawn) { spawn = true; player.transform.position = new Vector3(Random.Range(-1.3f, 2.8f), -4f, 0); } }
            if (player.GetComponent<Player>().player == 4 && Input.GetKeyDown(KeyCode.Alpha4)) { if (!spawn) { spawn = true; player.transform.position = new Vector3(Random.Range(-1.3f, 2.8f), -4f, 0); } }
        }
        transform.position = player.transform.position;
        if (del==49) { del = 0;HP = 50; player.transform.position = new Vector3(0,0, -10);
            player.GetComponent<Player>().cdr = 0; player.GetComponent<Player>().cdel = 100; ;
        }
        if (player.GetComponent<Player>().role==2) {if (HP<20) { if (regDel > 0) { regDel -= 1; } }
            if (regDel <1) { regDel = 50;HP += 1; }
        }
    }
    void FixedUpdate()
    {
        if (dmg>0) { dmg -= 1; HP -= 0.1f; }
        if (urg) { heal += 1; }
        if (heal>24) { heal = 0;HP+=1; }
        if (HP<=0) { del = 50;
            dmg = 0;
            score.GetComponent<numbers>().convO -= 1;
            player.GetComponent<Player>().axe.SetActive(false);
            player.GetComponent<Player>().shield.SetActive(false);
            player.GetComponent<Player>().sword.SetActive(false);
            player.GetComponent<Player>().dagger.SetActive(false);
            player.GetComponent<Player>().bow.SetActive(false);
            player.GetComponent<Player>().pole.SetActive(false);
            player.GetComponent<Player>().hand.SetActive(false);
            player.GetComponent<Player>().arc.SetActive(false);
            Instantiate(death, transform.position+new Vector3(0,0,0), transform.rotation);
        }
    }
}
