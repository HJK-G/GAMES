public abstract class Character
{
    public string name;
    public string description;

    public int strength;
    public int dexterity;
    public int agility;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int influence;
    public int luck;

    public string abilityName;
    public string abilityDescription;
    public int abilityCooldown;

    public abstract void Update();
    public abstract void UseAbility();
}

class HJK : Character
{
    public HJK()
    {
        name = "HJK";
        description = "god?";

        strength = 5;
        dexterity = 7;
        agility = 7;
        constitution = 2;
        intelligence = 8;
        wisdom = 8;
        influence = 4;
        luck = 1;

        abilityName = "Yeet";
        abilityDescription = "Channel for one second before dealing 10000 damage in an area around you and revive with half drowsiness, scales with strength and cannot critically strike.\nCost:\nAll drowsiness and lucidity";
    }

    public bool usingAbility = false;
    public override void Update()
    {

    }

    public override void UseAbility()
    {
        
    }
}
