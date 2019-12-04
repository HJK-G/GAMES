using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Selector : MonoBehaviourPunCallbacks
{
    public int selection;
    static Vector3 pos = new Vector3(0, 2, 0);
    public GameObject mainMenu;
    public GameObject selectModeMenu;
    public GameObject selectChampionMenu;
    public GameObject connectingScreen;
    bool selectingMode;

    public GameObject mainCam;
    bool scrollable;

    static Vector3 move = new Vector3(0, 0.3f, 0);

    public GameObject creditsCam;
    int creditPos;
    public int endCreditPos;
    bool onCredits;

    static readonly string gameVersion = "1";
    bool isConnecting;

    public void Start()
    {
        mainMenu.SetActive(true);
        selectModeMenu.SetActive(false);
        selectChampionMenu.SetActive(false);
        connectingScreen.SetActive(false);
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Update()
    {
        if (isConnecting || onCredits)
        {
            return;
        }

        if (scrollable)
        {
            if (Input.GetKey(KeyCode.S))
            {
                mainCam.transform.position -= move;
            }
            if (Input.GetKey(KeyCode.W))
            {
                mainCam.transform.position += move;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                mainCam.transform.position = new Vector3(0, 0, -10);
                selection = 1;
                transform.position = new Vector3(-1.5f, 3.2f, 0);
                scrollable = false;
            }
        }
        else if (!selectingMode)
        {
            if (Input.GetKeyDown(KeyCode.W) && selection > 1)
            {
                transform.position += pos;
                selection -= 1;
            }
            if (Input.GetKeyDown(KeyCode.S) && selection < 5)
            {
                transform.position -= pos;
                selection += 1;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                switch (selection)
                {
                    case 1:
                        mainMenu.SetActive(false);
                        selectModeMenu.SetActive(true);
                        selectingMode = true;
                        transform.position = new Vector3(-3, 3, 0);
                        break;
                    case 2:
                        mainCam.transform.position = new Vector3(90, 0, -10);
                        scrollable = true;
                        break;
                    case 3:
                        mainCam.transform.position = new Vector3(38, 0, -10);
                        scrollable = true;
                        break;
                    case 4:
                        mainCam.SetActive(false);
                        creditsCam.SetActive(true);
                        onCredits = true;
                        break;
                    case 5:
                        break;
                }
            }
        }
        else
        {
            if (selection == -1)
            {
                Rotator rotator = selectChampionMenu.GetComponentInChildren<Rotator>();
                if (System.Math.Abs(rotator.direction) < 1)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        rotator.selection--;
                        rotator.direction = 360.0f / Champion.numChampions;
                        rotator.selection = (Champion.numChampions + rotator.selection) % Champion.numChampions;
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        rotator.selection++;
                        rotator.direction = -360.0f/Champion.numChampions;
                        rotator.selection %= Champion.numChampions;
                    }
                    else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    {
                        PlayerPrefs.SetInt("ChampionSelected", rotator.selection);
                        isConnecting = true;
                        selectChampionMenu.SetActive(false);
                        connectingScreen.SetActive(true);
                        if (PhotonNetwork.IsConnected)
                        {
                            PhotonNetwork.JoinRandomRoom();
                        }
                        else
                        {
                            PhotonNetwork.GameVersion = gameVersion;
                            PhotonNetwork.ConnectUsingSettings();
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.W) && selection > 1)
                {
                    transform.position += pos * 4;
                    selection -= 2;
                }
                if (Input.GetKeyDown(KeyCode.S) && selection < 3)
                {
                    transform.position -= pos * 4;
                    selection += 2;
                }
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    switch (selection)
                    {
                        case 1:
                            selectModeMenu.SetActive(false);
                            selectChampionMenu.SetActive(true);
                            selection = -1;
                            GetComponent<SpriteRenderer>().enabled = false;
                            break;
                        case 2:
                            //SceneManager.LoadScene("Tournament");
                            break;
                        case 3:
                            mainMenu.SetActive(true);
                            selectModeMenu.SetActive(false);
                            selection = 1;
                            selectingMode = false;
                            transform.position = new Vector3(-1.5f, 3.2f, 0);
                            break;
                    }
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (onCredits)
        {
            creditPos += 1;
            creditsCam.GetComponent<Transform>().transform.position += new Vector3(0, -0.05f, 0);
            if (creditPos > endCreditPos - 200)
            {
                creditsCam.GetComponent<AudioSource>().volume = (endCreditPos - creditPos) / 200f;
            }
            if (creditPos == endCreditPos)
            {
                mainCam.SetActive(true);
                creditsCam.SetActive(false);
                creditsCam.transform.position = new Vector3(0, -12, -10);
                mainCam.transform.position = new Vector3(0, 0, -10);
                selection = 1;
                transform.position = new Vector3(-1.5f, 3.2f, 0);
                onCredits = false;
            }
        }
        if (isConnecting)
        {
            connectingScreen.transform.Rotate(0, 0, 1f);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster called by pun");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
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

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("load ffa");
            PhotonNetwork.LoadLevel("FFA");
        }
    }

}
