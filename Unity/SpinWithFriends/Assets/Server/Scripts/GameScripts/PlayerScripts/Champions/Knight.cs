using UnityEngine;

public class Knight : Champion
{
    public Knight()
    {
        healthReset = 100;
        health = healthReset;
        speedReset = 3;
        speed = speedReset;
        abilityTimerReset = 150;
        abilityTime = 0;
        abilityCooldownReset = 400;
        abilityCooldown = 0;

        weapon = new Sword();
    }

    public override void UseAbility()
    {
        if (abilityCooldown > 0)
        {
            return;
        }

        ((Sword)weapon).ignoreBounce = true;

        abilityTime = abilityTimerReset;
        abilityCooldown = abilityCooldownReset;
    }


    public override void ResetAbility()
    {
        weapon.spinSpeed = weapon.spinSpeedReset * weapon.direction;
        ((Sword)weapon).ignoreBounce = false;
    }
}
