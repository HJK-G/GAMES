using UnityEngine;

public abstract class Champion
{
    public static readonly int numChampions = 6;
    public float health;
    public float healthReset;
    public float speed;
    public float speedReset;
    public float abilityCooldown;
    public float abilityCooldownReset;
    public float abilityTime;
    public float abilityTimerReset;

    public Weapon weapon;

    public GameObject player;

    public abstract void UseAbility();

    public void Update()
    {
        if (abilityCooldown >= 0)
        {
            abilityCooldown--;

            if (abilityTime >= 1)
            {
                abilityTime--;
            }
            else if (abilityTime >= 0)
            {
                abilityTime--;
                ResetAbility();
            }
        }

        weapon.Update();
    }

    public abstract void ResetAbility();
}
