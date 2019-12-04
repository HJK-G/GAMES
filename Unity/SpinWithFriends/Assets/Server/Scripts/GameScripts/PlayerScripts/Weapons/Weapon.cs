using UnityEngine;

public abstract class Weapon
{
    public float damageReset;
    public float damage;
    public float spinSpeedReset;
    public float spinSpeed;
    public int direction = -1;

    public void Update()
    {
        
    }

    public abstract void collided(Collision2D col);
}
