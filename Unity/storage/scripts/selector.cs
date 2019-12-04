using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selector : MonoBehaviour
{
    public int selection;
    Vector3 pos;
    public string FFA;
    public string tour;
    public string credits;
    public GameObject opt1;
    public GameObject opt2;
    public GameObject dis1;
    public GameObject dis2;
    public GameObject backar;
    bool two;

    public GameObject cam;
    bool scroll;

    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(0,2,0);
        if (scroll) { if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                cam.transform.position = new Vector3(0, 0, -10); scroll = false; return;
            } }
        if (!two&&!scroll)
        {
            if (Input.GetKeyDown(KeyCode.W) && selection > 1) { transform.position += pos; selection -= 1; }
            if (Input.GetKeyDown(KeyCode.S) && selection < 5) { transform.position -= pos; selection += 1; }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                if (selection == 1) {
                    starty();
                }
                if (selection == 2) { cam.transform.position = new Vector3(90, 0, -10); scroll = true; }
                if (selection == 3) { cam.transform.position = new Vector3(38,0,-10); scroll = true; }
                if (selection == 4) { SceneManager.LoadScene(credits); }
                if (selection == 5) {
                    starty();
                }
            }
        }
        else
        {
            if (!scroll)
            {
                if (Input.GetKeyDown(KeyCode.W) && selection > 1) { transform.position += pos * 2; selection -= 1; }
                if (Input.GetKeyDown(KeyCode.S) && selection < 3) { transform.position -= pos * 2; selection += 1; }
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    if (selection == 1) { SceneManager.LoadScene(FFA); }
                    if (selection == 2) { SceneManager.LoadScene(tour); }
                    if (selection==3) { backy(); }
                }
            }

        }
    }
    void FixedUpdate()
    {
        move = new Vector3(0, 0.3f, 0);
        if (scroll)
        {
            if (Input.GetKey(KeyCode.S)) { cam.transform.position -= move; }
            if (Input.GetKey(KeyCode.W)) { cam.transform.position += move; }
        }
    }
    void starty()
    {
        opt1.SetActive(false); opt2.SetActive(true); two = true; selection = 1;
        transform.position = new Vector3(-3, 3, 0);
        dis1.SetActive(false);
        dis2.SetActive(false);
        backar.SetActive(true);
    }
    void backy()
    {
        opt1.SetActive(true); opt2.SetActive(false); two = false; selection = 1;
        transform.position = new Vector3(-1.5f, 3.2f, 0);
        dis1.SetActive(true);
        dis2.SetActive(true);
        backar.SetActive(false);
    }
}
