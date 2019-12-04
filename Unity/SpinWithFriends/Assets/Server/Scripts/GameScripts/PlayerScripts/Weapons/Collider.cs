using UnityEngine;

public class Collider : MonoBehaviour
{
    public Player player;
    private int delay = -1;
    private Collision2D col;

    public void Start()
    {
        player = GetComponentInParent<Player>();

        Physics.autoSimulation = false;
    }

    public void FixedUpdate()
    {
        if (delay >= 0)
        {
            delay--;
        }
        if (delay == 0)
        {
            player.champions[player.championSelect].weapon.collided(col);
            delay = -1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!player.photonView.IsMine)
        {
            return;
        }
        Debug.Log("hit");
        delay = 1;
        col = other;
    }
}
