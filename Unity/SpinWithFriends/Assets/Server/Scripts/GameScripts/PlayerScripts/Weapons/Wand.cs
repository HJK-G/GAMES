using UnityEngine;

public class Wand : Weapon
{
    public Wand()
    {
        spinSpeedReset = 6f;
        spinSpeed = spinSpeedReset;
        damageReset = 10;
        damage = damageReset;

    }

    public override void collided(Collision2D col)
    {
        direction = -direction;

        if (col.gameObject.name == "Player(Clone)")
        {
            Player otherPlayer = col.gameObject.GetComponent<Player>();
            otherPlayer.champions[otherPlayer.championSelect].health -= damage;
            Debug.Log(otherPlayer.champions[otherPlayer.championSelect].health);
        }
    }
}
