public static class AbilityTree
{
    public static Ability[] abilities = new Ability[10];

    public static void UseAbility(int abilityNum)
    {
        abilities[abilityNum].UseAbility();
    }
}

public abstract class Ability
{
    protected float lucidityCost;

    protected bool unlocked;

    public abstract void UseAbility();
}

class Fireball : Ability
{
    public override void UseAbility()
    {

    }
}

