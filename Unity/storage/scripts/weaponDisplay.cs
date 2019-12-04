using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDisplay : MonoBehaviour
{
    public int weapon;
    int delay;
    public Sprite axe;
    public Sprite sword;
    public Sprite shield;
    public Sprite dag;
    public Sprite bow;
    public Sprite pole;
    public Sprite arc;
    // Start is called before the first frame update
    void Start()
    {
        weapon = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 1);
        delay += 1;
        if (delay>179)
        {
            delay = 0;
            weapon += 1;
        }
        if (weapon==1) { GetComponent<SpriteRenderer>().sprite = axe; transform.localScale = new Vector3(0.6f,0.6f,1); }
        if (weapon == 2) { GetComponent<SpriteRenderer>().sprite = sword; transform.localScale = new Vector3(.8f, .8f, 1); }
        if (weapon == 3) { GetComponent<SpriteRenderer>().sprite = shield; transform.localScale = new Vector3(3f, 3f, 1); }
        if (weapon == 4) { GetComponent<SpriteRenderer>().sprite = dag; transform.localScale = new Vector3(0.3f, 0.3f, 1); }
        if (weapon == 5) { GetComponent<SpriteRenderer>().sprite = bow; transform.localScale = new Vector3(0.6f, 0.6f, 1); }
        if (weapon == 6) { GetComponent<SpriteRenderer>().sprite = pole; transform.localScale = new Vector3(1.5f, 1.3f, 1); }
        if (weapon == 7) { GetComponent<SpriteRenderer>().sprite = arc; transform.localScale = new Vector3(.9f, 1f, 1); }
        if (weapon==8) { weapon = 1; }
    }
}
