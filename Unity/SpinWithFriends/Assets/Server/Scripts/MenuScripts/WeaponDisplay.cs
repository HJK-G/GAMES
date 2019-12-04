using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    int weapon = 0;
    int delay = 0;
    public Sprite[] weaponsSprites;
    static Vector3[] scales = { new Vector3(0.6f, 0.6f, 1), new Vector3(.8f, .8f, 1), new Vector3(3f, 3f, 1), new Vector3(0.3f, 0.3f, 1), new Vector3(0.6f, 0.6f, 1), new Vector3(1.5f, 1.3f, 1), new Vector3(.9f, 1f, 1) };


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 1);
        delay += 1;
        if (delay > 179)
        {
            delay = 0;
            GetComponent<SpriteRenderer>().sprite = weaponsSprites[weapon];
            transform.localScale = scales[weapon];
            weapon = (weapon + 1) % 7;

        }
    }
}
