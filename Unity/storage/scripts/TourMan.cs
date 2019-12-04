using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TourMan : MonoBehaviour
{
    public GameObject HB1;
    public GameObject HB2;
    public GameObject p1;
    public GameObject p2;
    public static int del;
    public string back;
    public GameObject border;
    public GameObject borderr;
    bool reset;
    public Transform healP;
    int dell;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dell>0) { dell += 1; }
        if (dell==2) {
            p1.transform.position = new Vector3(-3, 0, 0);
            p2.transform.position = new Vector3(3, 0, 0);
            dell = 0;
        }
        if (HB1.GetComponent<xq>().HP<=0|| HB2.GetComponent<xq>().HP <= 0) {
            del = 1; //p1.transform.position = new Vector3(-300, 0, 0); p2.transform.position = new Vector3(-300, 0, 0);
        }
        if (del>0) { del += 1; }
        if (del>36) {
            Destroy(borderr);
            GameObject Border = Instantiate(border, transform.position, transform.rotation);
            borderr = Border;
            del = 0;
            Vector3 rotty = transform.rotation.eulerAngles;
            rotty.z = 0.0f;
            healP.rotation = Quaternion.Euler(rotty);
            HB1.GetComponent<xq>().HP = 0; HB2.GetComponent<xq>().HP = 0;
            dell = 1;
            /*SceneManager.LoadScene(back);*/
        }
    }
}
