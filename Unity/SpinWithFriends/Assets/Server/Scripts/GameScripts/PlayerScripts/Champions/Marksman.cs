using UnityEngine;

public class Brute : Champion
{
    public Brute()
    {
        healthReset = 100;
        health = healthReset;
        speedReset = 3;
        speed = speedReset;
        abilityTimerReset = 12;
        abilityTime = 0;
        abilityCooldownReset = 500;
        abilityCooldown = 0;

        weapon = new Axe();
    }

    public override void UseAbility()
    {
        if (abilityCooldown > 0)
        {
            return;
        }

        weapon.spinSpeed *= 5f;
        ((Axe)weapon).ignoreBounce = true;

        abilityTime = abilityTimerReset;
        abilityCooldown = abilityCooldownReset;
    }


    public override void ResetAbility()
    {
        weapon.spinSpeed = weapon.spinSpeedReset * weapon.direction;
        ((Axe)weapon).ignoreBounce = false;
    }
}
