using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //skrypt odpoiedzialny za grę

    bool hasEnded = false;
    bool running = false;
    GameObject[] player;
    string playerName;
    public GameObject txt;

    public void TheEndgame()
    {
        if (hasEnded)
        {
            return;
        }
        //tutaj robię magię
        //player = GameObject.FindGameObjectsWithTag("player");
        //if (player.Length ==1)
        //{
        //   playerName = GameObject.FindGameObjectWithTag("player").name;
        //}
        //txt.SetActive(true);
        //txt.GetComponent<Text>().text = "Gratulacje! Wygrał gracz " + playerName + "!";
        // tutaj kończę magię

        Debug.Log("ZDECHŁEŚ");
        hasEnded = true;
        StartCoroutine(PlayEndgame());
    }

    IEnumerator PlayEndgame()
    {
        Debug.Log("KONIEC GRY");

        //po czasie zrestartuj gre
        yield return new WaitForSeconds(5f);
        //bool hasEnded = false;
        //bool running = false;
        SceneManager.LoadScene("Lobby");

    }

    //IEnumerator WaitSecond()
    //{
    //    yield return new WaitForSeconds(1);
    //}
}
