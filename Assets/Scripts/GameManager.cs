using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Prototype.NetworkLobby;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;

public class GameManager : NetworkBehaviour
{
    //skrypt odpoiedzialny za grę

    bool hasEnded = false;
    bool running = false;
    GameObject[] player;
    string playerName;
    public GameObject txt;
    GameObject[] players;

    [SyncVar]
    string winner;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");
        StartCoroutine(WaitForPlayers());
        StopPlayers();
        RpcSetStartingPositions(players);
        StartCoroutine(EnableTails());
        StartCoroutine(SetPlayersSpeed(1.5f));     
    }

    //Set spped of players to 0
    void StopPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject p in players)
        {
            p.transform.GetComponentInChildren<Movement>().speed = 0f;
            p.transform.GetComponentInChildren<Movement>().rotationSpeed = 0f;
        }
    }

    IEnumerator WaitForPlayers()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator SetPlayersSpeed(float speed)
    {
        yield return new WaitForSeconds(2);
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject p in players)
        {
            p.transform.GetComponentInChildren<Movement>().speed = speed;
            p.transform.GetComponentInChildren<Movement>().rotationSpeed = 200f;
        }
    }

    //Set correct spawn points
    [ClientRpc]
    void RpcSetStartingPositions(GameObject[] players)
    {
        Vector2[] SpawnPoints = new Vector2[2];
        SpawnPoints[0].Set(-5, 0);
        SpawnPoints[1].Set(5, 0);
        Debug.Log(players[0].transform.name);
        Debug.Log(players[1].transform.name);
        if (players[1] != null)
        {
            for (int i = 0; i<2; i++)
            {
                players[i].transform.position = SpawnPoints[i];
            }
        }
    }

    //Enable players tails
    IEnumerator EnableTails()
    {
        yield return new WaitForSeconds(1);
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject p in players)
        {
            p.transform.GetComponentInChildren<LineRenderer>().enabled = true;
            p.transform.GetComponentInChildren<TailScript>().enabled = true;
            //p.transform.GetComponentInChildren<TailScript>().ResetPoints();
        }
    }

    /*void SetScore()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        GameObject.FindGameObjectWithTag("ScorePlayer0").GetComponent<TextMeshProUGUI>().text = players[0].GetComponent<Player>().points.ToString();
        GameObject.FindGameObjectWithTag("ScorePlayer0").GetComponent<TextMeshProUGUI>().color = players[0].GetComponent<Player>().playerColor;
        GameObject.FindGameObjectWithTag("ScorePlayer1").GetComponent<TextMeshProUGUI>().text = players[1].GetComponent<Player>().points.ToString();
        GameObject.FindGameObjectWithTag("ScorePlayer1").GetComponent<TextMeshProUGUI>().color = players[1].GetComponent<Player>().playerColor;
    }*/

    [ClientRpc]
    public void RpcTheEndgame(string name)
    {
        StopPlayers();

        winner = name;
        if (hasEnded)
        {
            return;
        }

        txt.SetActive(true);
        txt.GetComponent<TextMeshProUGUI>().text ="Winner is " + winner + "!";

        Debug.Log("ZDECHŁEŚ");
        hasEnded = true;
        StartCoroutine(PlayEndgame());
    }

    IEnumerator PlayEndgame()
    {
        Debug.Log("KONIEC GRY");

        //po czasie zrestartuj gre
        yield return new WaitForSeconds(3f);
        hasEnded = false;
        running = false;

        //use backbutton
        GameObject backButton = GameObject.FindGameObjectWithTag("Back").gameObject;
        Debug.Log("backbutton: " + backButton);
        backButton.transform.GetComponentInChildren<LobbyManager>().GoBackButton();
    }
}
