using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //skrypt odpoiedzialny za grę

    bool hasEnded = false;
    bool running = false;
    GameObject[] players;

    private void Update()
    {
   
    }

    public void TheEndgame()
    {
        if (hasEnded)
        {
            return;
        }

        // dodać txxtboxy!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        Debug.Log("ZDECHŁEŚ");
        hasEnded = true;
        StartCoroutine(PlayEndgame());
    }

    IEnumerator PlayEndgame()
    {
        Debug.Log("KONIEC GRY");

        //po sekundzie zrestartuj gre
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(1);
    }
}
