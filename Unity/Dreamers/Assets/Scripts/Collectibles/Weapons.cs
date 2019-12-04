using UnityEngine;

public class Weapons : MonoBehaviour
{
    public static Weapons self;
    public Weapon[] weapons;

    public void Start()
    {
        self = this;
    }
}
