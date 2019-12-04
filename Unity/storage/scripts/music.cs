using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public GameObject battleofkings;
    public GameObject fall;
    public GameObject endgame;
    public GameObject rapture;
    public GameObject redemption;
    public static bool play;
    public bool ffa;
    // Start is called before the first frame update
    void Start()
    {
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (ffa)
            {
                int x = Random.Range(1, 3);
                if (x == 1) { Instantiate(battleofkings, transform.position, transform.rotation); }
                if (x == 2) { Instantiate(endgame, transform.position, transform.rotation); }
            }
            if (!ffa)
            {
                int x = Random.Range(1, 4);
                if (x == 1) { Instantiate(fall, transform.position, transform.rotation); }
                if (x == 2) { Instantiate(rapture, transform.position, transform.rotation); }
                if (x == 3) { Instantiate(redemption, transform.position, transform.rotation); }
            }
            play = false;
        }
        if (Input.GetKey(KeyCode.Tab)&&Input.GetKeyDown(KeyCode.M)) { play = true; }
    }
}
