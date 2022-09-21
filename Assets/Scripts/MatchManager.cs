using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class MatchManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public static MatchManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum EventCodes : byte
    {
        NewPlayer,
        ListPlayers,
        UpdateStat,

    }

    public List<PlayerInfo> allPlayers = new List<PlayerInfo>();
    private int index;

    public EventCodes theEvent;

    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene(0);
        }  
    }

    void Update()
    {

    }

    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code < 200)
        {
            EventCodes theEvent = (EventCodes)photonEvent.Code;
            object[] data = (object[])photonEvent.CustomData;

            switch (theEvent)
            {
                case EventCodes.NewPlayer:

                    NewPlayerReceive(data);

                    break;

                case EventCodes.ListPlayers:

                    ListPlayersReceive(data);

                    break;

                case EventCodes.UpdateStat:

                    UpdateStatsReceive(data);

                    break;
            }
        }
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void NewPlayerSend()
    {
        
    }

    public void NewPlayerReceive(object[] dataReceived)
    {
        
    }

    public void ListPlayersSend()
    {

    }

    public void ListPlayersReceive(object[] dataReceived)
    {

    }

    public void UpdateStatsSend()
    {

    }

    public void UpdateStatsReceive(object[] dataReceived)
    {

    }
}

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public int actor, kills, death;

    public PlayerInfo(string _name, int _actor, int _kills, int _deaths)
    {
        name = _name;
        actor = _actor;
        kills = _kills;
        death = _deaths;
    }
}
