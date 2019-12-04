using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EOneTenHund : MonoBehaviour {
    public int value;
    public Sprite[] nums = new Sprite[10];

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E)) { MapSave.Instance.EOne += 1; }
        if (value == 1)
        {
            GetComponent<SpriteRenderer>().sprite = nums[MapSave.Instance.EOne];

        }
        if (value == 10)
        {
            GetComponent<SpriteRenderer>().sprite = nums[MapSave.Instance.ETen];
        }
        if (value == 100)
        {
            GetComponent<SpriteRenderer>().sprite = nums[MapSave.Instance.EHund];
        }


    }
}
