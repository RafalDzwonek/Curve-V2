using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Prototype.NetworkLobby;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    //skrypt odpoiedzialny za grę

    bool hasEnded = false;
    bool running = false;
    GameObject[] player;
    string playerName;
    public GameObject txt;

    [SyncVar]
    string winner;

    void StopPlayers()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("player"))
        {
            p.transform.GetComponentInChildren<Movement>().speed = 0f;
            p.transform.GetComponentInChildren<Movement>().rotationSpeed = 0f;
        }
    }

    [ClientRpc]
    public void RpcTheEndgame(string name)
    {
        StopPlayers();

        winner = name;
        if (hasEnded)
        {
            return;
        }
        //tutaj robię magię

        //if (testowy != null)
        //{
            txt.SetActive(true);
            txt.GetComponent<TextMeshProUGUI>().text ="Winner is " + winner + "!";
        //}
        
        // tutaj kończę magię

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
