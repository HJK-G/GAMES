using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject text;
    public void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
            if (PhotonNetwork.InRoom)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster called by pun");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected called by pun");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnjoinRandomFailed called by pun");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom called by pun");
        text.GetComponent<TextMesh>().text = "start";
    }

}