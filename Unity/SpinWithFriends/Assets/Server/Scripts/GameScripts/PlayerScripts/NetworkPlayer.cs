using Photon.Pun;
using UnityEngine;

public class NetworkPlayer : MonoBehaviourPun, IPunObservable
{
    public Player player;
    private Vector3 RemotePlayerPosition;

    public void Start()
    {
    }

    public void Update()
    {
        if (photonView.IsMine)
        {
            return;
        }

        var lagDistance = RemotePlayerPosition - transform.position;
        if (lagDistance.magnitude > 5f)
        {
            transform.position = RemotePlayerPosition;
            lagDistance = Vector3.zero;
        }
        if (lagDistance.magnitude < .05f)
        {
            transform.position = RemotePlayerPosition;
        }
        else
        {
            player.GetComponent<Rigidbody2D>().velocity = lagDistance.normalized * player.champions[player.championSelect].speed;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position.x);
            stream.SendNext(transform.position.y);

            stream.SendNext(player.championSelect);
            stream.SendNext(player.champions[player.championSelect].health);
            stream.SendNext(player.champions[player.championSelect].speed);
            stream.SendNext(player.champions[player.championSelect].abilityCooldown);
            stream.SendNext(player.champions[player.championSelect].abilityTime);
        }
        else
        {
            RemotePlayerPosition = new Vector3((float)stream.ReceiveNext(), (float)stream.ReceiveNext(), 0);

            player.championSelect = (int)stream.ReceiveNext();
            player.champions[player.championSelect].health = (float)stream.ReceiveNext();
            player.champions[player.championSelect].speed = (float)stream.ReceiveNext();
            player.champions[player.championSelect].abilityCooldown = (float)stream.ReceiveNext();
            player.champions[player.championSelect].abilityTime = (float)stream.ReceiveNext();
        }
    }
}
