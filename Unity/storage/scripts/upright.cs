using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotty = transform.rotation.eulerAngles;
        rotty.z = 0.0f;
        transform.rotation = Quaternion.Euler(rotty);
    }
}
