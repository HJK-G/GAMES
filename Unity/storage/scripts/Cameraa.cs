using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;
    public static bool track;
    public static float slow;
    public static int zoom;
    public float display;
    float size;
    float sizeD;
    public static int map=3;
    bool third;
    bool fourth;
    // Start is called before the first frame update
    void Start()
    {
        size = 0;
        map = 4;
        track = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.X)) { map -= 1; }
            display = slow;
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (track) { track = false; return; }
                if (!track) { track = true; }
            }
            if (Input.GetKeyDown(KeyCode.Equals)) { Time.timeScale += 0.1f; }
            if (Input.GetKeyDown(KeyCode.Minus)) { Time.timeScale -= 0.1f; }
            if (Input.GetKeyDown(KeyCode.Alpha0)) { Time.timeScale = 1f; }
            if (Input.GetKeyDown(KeyCode.Alpha8)) { Time.timeScale = 0.8f; }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { third = true; }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { fourth= true; }
        }
        if (track) {
            if (!third&&!fourth) { Camera.main.orthographicSize = Mathf.Sqrt(Mathf.Abs(player1.position.x - player2.position.x) * Mathf.Abs(player1.position.x - player2.position.x) + Mathf.Abs(player1.position.y - player2.position.y) * Mathf.Abs(player1.position.y - player2.position.y))/ (2 + sizeD); }
            if (Camera.main.orthographicSize < 2) { Camera.main.orthographicSize = 2; }
                if (slow > 0) { slow -= 1; }
                if (slow==1) { Time.timeScale +=0.6f;}
                if (slow<1) {
                if (!third&&!fourth) { transform.position = new Vector3((player1.position.x + player2.position.x) / 2f, (player1.position.y + player2.position.y) / 2f, -10); }
                else if (third&&!fourth) { transform.position = new Vector3((player1.position.x + player2.position.x+ player3.position.x) / 3f, (player1.position.y + player2.position.y+ player3.position.y) / 3f, -10); }
                else if (third && fourth) { transform.position = new Vector3((player1.position.x + player2.position.x + player3.position.x+ player4.position.x) / 4f, (player1.position.y + player2.position.y + player3.position.y+ player4.position.y) / 4f, -10); }
                if (Input.GetKeyDown(KeyCode.Equals) && !Input.GetKey(KeyCode.Tab)) { sizeD += 0.1f; }
                if (Input.GetKeyDown(KeyCode.Minus) && !Input.GetKey(KeyCode.Tab)) { sizeD -= 0.1f; }
            }
            if (zoom > 0&&!third) { zoom -= 1; Camera.main.orthographicSize += 0.2f; }
        }
        else { Camera.main.orthographicSize = size+6; transform.position = new Vector3(0,0,-10);
            if (Input.GetKeyDown(KeyCode.Equals) && !Input.GetKey(KeyCode.Tab)) { size -= 0.2f; }
            if (Input.GetKeyDown(KeyCode.Minus) && !Input.GetKey(KeyCode.Tab)) { size += 0.2f; }
        }
    }
}
