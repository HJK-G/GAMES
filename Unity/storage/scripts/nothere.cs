using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nothere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        //if (col.gameObject.GetComponent<TerRand>()!=null)
        
            col.gameObject.GetComponent<TerRand>().rand = true;
        
    }
}
