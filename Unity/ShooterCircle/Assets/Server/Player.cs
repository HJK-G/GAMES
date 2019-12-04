using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{

    public Rigidbody2D rb;
    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    public void Update()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        vel.Normalize();
        vel.Scale(new Vector3(10, 10, 10));
        rb.velocity = vel;


        if (Input.GetKeyDown(KeyCode.U))
        {
            GameObject b=PhotonNetwork.Instantiate("bullet", transform.position, transform.rotation);
            Destroy(b, 5f);
        }
    }
}