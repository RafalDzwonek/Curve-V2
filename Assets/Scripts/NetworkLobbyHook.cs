using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class NetworkLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetupLocalPlayer localPlayer = gamePlayer.GetComponent<SetupLocalPlayer>();
        localPlayer.playerColor = lobby.playerColor;
        localPlayer.playerName = lobby.playerName;
        Debug.Log("Uruchomione");     
    }

    void Start()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("player"))
        {
            this.name = GetComponentInChildren<SetupLocalPlayer>().
        }
    }

}
