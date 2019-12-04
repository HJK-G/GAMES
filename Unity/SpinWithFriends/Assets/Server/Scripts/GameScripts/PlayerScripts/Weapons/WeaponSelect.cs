using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public GameObject[] weapons = new GameObject[Champion.numChampions];
    public Player player;

    public void Start()
    {
        for(int i = 0; i < Champion.numChampions; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[player.championSelect].SetActive(true);
    }
}
