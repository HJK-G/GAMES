using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public void Start()
    {
        Debug.Log("instantiating local player");
        Player player=PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity, 0).GetComponent<Player>();
        player.championSelect = PlayerPrefs.GetInt("ChampionSelected");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("trying to load level but not master client");
        }
        Debug.Log("Loading level");
        PhotonNetwork.LoadLevel("FFA");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.LogFormat("{0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.LogFormat("{0} left room", otherPlayer.NickName);
    }
}