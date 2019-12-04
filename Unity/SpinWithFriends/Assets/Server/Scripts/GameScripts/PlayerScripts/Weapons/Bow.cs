using UnityEngine;

public class Axe : Weapon
{
    public bool ignoreBounce;

    public Axe()
    {
        spinSpeedReset = 6f;
        spinSpeed = spinSpeedReset;
        damageReset = 10;
        damage = damageReset;

        ignoreBounce = false;
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
