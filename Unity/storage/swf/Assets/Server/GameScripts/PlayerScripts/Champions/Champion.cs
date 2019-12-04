using UnityEngine;

public class Champion : MonoBehaviour
{
    int health;
    Weapon weapon;
    int speed;
    int abilityCooldown;
    GameObject abilityIndicator;

    public void UseAbility()
    {
        abilityIndicator.SetActive(false);
    }

    public void Update()
    {
        if (abilityCooldown > 0)
        {
            abilityCooldown--;
        }

        if (abilityCooldown < 0)
        {
            abilityIndicator.SetActive(true);
            abilityCooldown = -1;
        }
    }


}
