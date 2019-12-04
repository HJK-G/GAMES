using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform[] championTransforms = new Transform[Champion.numChampions];

    public Transform background;

    public int radius;

    public int selection = 0;
    public float direction = 0;

    public void OnEnable()
    {
        transform.localPosition = new Vector3(0, 0, radius);
        background.localPosition = new Vector3(0, 0, radius);

        for (int i = 0; i < Champion.numChampions; i++)
        {
            float angle = 360.0f / Champion.numChampions * i;
            championTransforms[i].localPosition = new Vector3(0, radius * Mathf.Sin(Mathf.Deg2Rad * angle), -radius * Mathf.Cos(Mathf.Deg2Rad * angle));
            championTransforms[i].localRotation = Quaternion.Euler(angle, 0, 0);

        }
    }

    public void FixedUpdate()
    {
        if (Mathf.Abs(direction) > 1)
        {
            transform.Rotate(Mathf.Sign(direction)*4, 0, 0);
            direction += -Mathf.Sign(direction)*4;
        }
        else
        {
            direction = 0;
            transform.rotation = Quaternion.Euler(360.0f / Champion.numChampions * -selection, 0, 0);
        }
    }
}
