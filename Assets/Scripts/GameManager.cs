using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Prototype.NetworkLobby;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //skrypt odpoiedzialny za grę

    bool hasEnded = false;
    bool running = false;
    GameObject[] player;
    string playerName;
    public GameObject txt;

    private void Start()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("player"))
        {
            if (p.name != null)
            p.name = p.GetComponentInChildren<SetupLocalPlayer>().playerName;
        }
    }

    public void TheEndgame()
    {
        if (hasEnded)
        {
            return;
        }
        //tutaj robię magię

        //if (testowy != null)
        //{
            playerName = GameObject.FindGameObjectWithTag("player").name;
            txt.SetActive(true);
            txt.GetComponent<TextMeshProUGUI>().text ="Gratulacje! Wygrał gracz " + playerName + "!";
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
        Button backButton = gameObject.GetComponent<LobbyManager>().backButton;
        backButton.GetComponentInChildren<LobbyManager>().GoBackButton();

    }

    //IEnumerator WaitSecond()
    //{
    //    yield return new WaitForSeconds(1);
    //}

}
