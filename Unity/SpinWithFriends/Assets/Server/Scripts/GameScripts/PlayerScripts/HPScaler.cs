using UnityEngine;

public class HPScaler : MonoBehaviour
{
    public Player player;
    private float barScale;

    void Start()
    {
        barScale = player.champions[player.championSelect].healthReset;
    }

    void FixedUpdate()
    {
        barScale = player.champions[player.championSelect].healthReset;

        Vector3 localScale = transform.localScale;
        localScale.x = player.champions[player.championSelect].health / barScale;
        transform.localScale = localScale;
    }
}
