using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string name;
    public string desc;
    public int timer;
    public int atkcd;

    public Transform firePt;
    public float dmg;
    public float spd;


    public int type;
    //0 =linear
    //1 =spread
    //2 =

    public Projectile projectile;

    public void Start()
    {

    }

    public void FixedUpdate()
    {
        if (atkcd > 0) { atkcd--; }
    }

    public void Attack()
    {
        if (atkcd > 0) { return; }

        switch (type)
        {
            case 0:
                Projectile proj = Instantiate(projectile, firePt.transform.position, firePt.transform.rotation);
                proj.rb.velocity = Player.self.transform.up * (spd + Player.spd);
                atkcd = timer;
                break;
        }
    }

    public void Damage(Enemy enemy)
    {
        switch (type)
        {
            case 0:
                enemy.health -= dmg * Player.self.character.strength + Player.RandRange(0, dmg) * Player.self.character.agility;
                break;
        }
    }
}
