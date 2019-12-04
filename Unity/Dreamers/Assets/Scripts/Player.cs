using UnityEngine;


public class Player : MonoBehaviour
{
    public static Player self;

    public Rigidbody2D rb;

    public Camera mainCam;
    public Transform cam;

    public Character character;

    public static float spd = 3;

    public int inventorySelect;
    public long money;

    void Start()
    {
        self = this;
        character = new HJK();
    }

    void FixedUpdate()
    {
        character.Update();

        HandleInput();
        cam.position = transform.position - new Vector3(0, 0, 10);
    }

    void HandleInput()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = transform.position - mousePos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);

        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        vel.Normalize();
        rb.velocity = vel * spd;

        if (Input.GetMouseButton(0))
        {
            Weapons.self.weapons[inventorySelect].Attack();
        }
    }

    public static float RandRange(float min, float max)
    {
        float mid = (min + max) / 2 * .3f + self.character.luck / 3.0f;
        float half = (max - min) / 2;
        float nmin = mid - half;
        float nmax = mid + half;

        return Mathf.Max(min, Mathf.Min((Random.Range(nmin, nmax) + Random.Range(nmin, nmax)) / 2, max));
    }
}
