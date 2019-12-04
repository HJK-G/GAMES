using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numbers : MonoBehaviour
{
    public int usage;
    public GameObject player;

    public int value;
    public int convO;
    int convT;
    int convH;

    public Sprite ze;
    public Sprite on;
    public Sprite tw;
    public Sprite th;
    public Sprite fo;
    public Sprite fi;
    public Sprite si;
    public Sprite se;
    public Sprite ei;
    public Sprite ni;

    float x;
    // Start is called before the first frame update
    void Start()
    {
        if (usage==2) { x = player.GetComponent<Player>().speed; }
        if (usage == 1) { convO = 3; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<Player>().Kills>0&&usage==1) { convO += 1;
            if (value == 1) { player.GetComponent<Player>().Kills = 0; }
        }
        if (usage == 2 && player.GetComponent<Player>().speed != x)
        {
            convO += 1;
            if (x > player.GetComponent<Player>().speed) { convO = 0; convT = 0; }
            if (value >0) { x = player.GetComponent<Player>().speed; }
        }
        if (usage == 3 && player.GetComponent<Player>().cdr != x)
        {
            convO += 1;
            if (x > player.GetComponent<Player>().cdr) { convO = 0; convT = 0; }
            if (value > 0) { x = player.GetComponent<Player>().cdr; }
        }

        if (convO == 10) { convO = 0; convT += 1; }
        if (convO < 0&&convT>0) { convO = 9; convT -= 1; } else if(convO<0){ convO = 0; }
        if (convT == 10) { convT = 0; convH += 1; }
        if (value == 1)
        {
            if (convO==0) { GetComponent<SpriteRenderer>().sprite = ze; }
            if (convO == 1) { GetComponent<SpriteRenderer>().sprite = on; }
            if (convO == 2) { GetComponent<SpriteRenderer>().sprite = tw; }
            if (convO == 3) { GetComponent<SpriteRenderer>().sprite = th; }
            if (convO == 4) { GetComponent<SpriteRenderer>().sprite = fo; }
            if (convO == 5) { GetComponent<SpriteRenderer>().sprite = fi; }
            if (convO == 6) { GetComponent<SpriteRenderer>().sprite = si; }
            if (convO == 7) { GetComponent<SpriteRenderer>().sprite = se; }
            if (convO == 8) { GetComponent<SpriteRenderer>().sprite = ei; }
            if (convO == 9) { GetComponent<SpriteRenderer>().sprite = ni; }
        }
        if (value == 10)
        {
            if (convT== 0) { GetComponent<SpriteRenderer>().sprite = ze; }
            if (convT== 1) { GetComponent<SpriteRenderer>().sprite = on; }
            if (convT== 2) { GetComponent<SpriteRenderer>().sprite = tw; }
            if (convT== 3) { GetComponent<SpriteRenderer>().sprite = th; }
            if (convT== 4) { GetComponent<SpriteRenderer>().sprite = fo; }
            if (convT== 5) { GetComponent<SpriteRenderer>().sprite = fi; }
            if (convT== 6) { GetComponent<SpriteRenderer>().sprite = si; }
            if (convT== 7) { GetComponent<SpriteRenderer>().sprite = se; }
            if (convT== 8) { GetComponent<SpriteRenderer>().sprite = ei; }
            if (convT== 9) { GetComponent<SpriteRenderer>().sprite = ni; }
        }
        if (value == 100)
        {
            if (convH== 0) { GetComponent<SpriteRenderer>().sprite = ze; }
            if (convH== 1) { GetComponent<SpriteRenderer>().sprite = on; }
            if (convH== 2) { GetComponent<SpriteRenderer>().sprite = tw; }
            if (convH== 3) { GetComponent<SpriteRenderer>().sprite = th; }
            if (convH== 4) { GetComponent<SpriteRenderer>().sprite = fo; }
            if (convH== 5) { GetComponent<SpriteRenderer>().sprite = fi; }
            if (convH== 6) { GetComponent<SpriteRenderer>().sprite = si; }
            if (convH== 7) { GetComponent<SpriteRenderer>().sprite = se; }
            if (convH== 8) { GetComponent<SpriteRenderer>().sprite = ei; }
            if (convH== 9) { GetComponent<SpriteRenderer>().sprite = ni; }
        }
    }
}
