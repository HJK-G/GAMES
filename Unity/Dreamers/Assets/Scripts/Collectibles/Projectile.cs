using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public void Update()
    {
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Weapons.self.weapons[Player.self.inventorySelect].Damage(collision.gameObject.GetComponent<Enemy>());
        }
        Destroy(gameObject);
    }
}
