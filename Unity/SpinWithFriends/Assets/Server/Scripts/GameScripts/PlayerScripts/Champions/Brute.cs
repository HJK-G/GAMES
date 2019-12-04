using UnityEngine;

public class Brute : Champion
{
    private int windupDelay=-1;

    public Brute()
    {
        healthReset = 100;
        health = healthReset;
        speedReset = 3;
        speed = speedReset;
        abilityTimerReset = 12;
        abilityTime = 0;
        abilityCooldownReset = 250;
        abilityCooldown = 0;

        weapon = new Axe();
    }

    public new void Update()
    {
        base.Update();

        if (((Axe)weapon).collidedPlayer)
        {
            ((Axe)weapon).collidedPlayer = false;
            health = Mathf.Min(healthReset, health + weapon.damage * .3f);
        }

        if (windupDelay >= 0)
        {
            windupDelay--;
        }
        if (windupDelay == 0)
        {
            weapon.direction = -weapon.direction;
            weapon.spinSpeed *= 5f;
            ((Axe)weapon).ignoreBounce = true;
            abilityTime = abilityTimerReset;
        }
    }

    public override void UseAbility()
    {
        if (abilityCooldown > 0)
        {
            return;
        }

        windupDelay = 5;
        weapon.direction = -weapon.direction;

        abilityCooldown = abilityCooldownReset;
    }


    public override void ResetAbility()
    {
        weapon.spinSpeed = weapon.spinSpeedReset * weapon.direction;
        ((Axe)weapon).ignoreBounce = false;
    }
}
