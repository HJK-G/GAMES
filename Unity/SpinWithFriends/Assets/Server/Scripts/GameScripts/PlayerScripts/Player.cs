using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public Champion[] champions = { new Brute(), new Knight(), new Assassin(), new Marksman(), new Warrior(), new Arcanist() };
    public int championSelect;

    public Rigidbody2D rb;

    public GameObject WeaponRotate;
    public GameManager GameManager;

    public GameObject[] Projectiles;

    public void Start()
    {
        championSelect = PlayerPrefs.GetInt("ChampionSelected");

        rb = GetComponent<Rigidbody2D>();

        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));

        Physics.autoSimulation = false;
    }

    public void FixedUpdate()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }

        ProcessInput();

        WeaponRotate.transform.Rotate(Vector3.forward * champions[championSelect].weapon.spinSpeed * champions[championSelect].weapon.direction);

        if (champions[championSelect].health <= 0)
        {
            champions[championSelect].health = champions[championSelect].healthReset;
            GameManager.LeaveRoom();
        }

        champions[championSelect].Update();
    }

    private void ProcessInput()
    {
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
        vel.Scale(new Vector3(champions[championSelect].speed, champions[championSelect].speed, 1));
        rb.velocity = vel;


        if (Input.GetKey(KeyCode.U))
        {
            champions[championSelect].UseAbility();
        }
    }
}