using UnityEngine;

public class Sword : Weapon
{
    public bool ignoreBounce=false;
    public Sword()
    {
        spinSpeedReset = 6f;
        spinSpeed = spinSpeedReset;
        damageReset = 10;
        damage = damageReset;

    }

    public override void collided(Collision2D col)
    {
        if (!ignoreBounce)
        {
            direction = -direction;
        }

        if (col.gameObject.name == "Player(Clone)")
        {
            Player otherPlayer = col.gameObject.GetComponent<Player>();
            otherPlayer.champions[otherPlayer.championSelect].health -= damage;
            Debug.Log(otherPlayer.champions[otherPlayer.championSelect].health);
        }
    }
}
