using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public Color playerColor;
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponentInChildren<Movement>().enabled = true;
        }
        //przypisz kolor glowie
        Renderer[] rends = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        r.material.color = playerColor;

        //przypisz kolor ogonowi
        LineRenderer[] line = GetComponentsInChildren<LineRenderer>();
        foreach (LineRenderer l in line)
        {
            l.startColor = playerColor;
            l.endColor = playerColor;
        }
    }

}
