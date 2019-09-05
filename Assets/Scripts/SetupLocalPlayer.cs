using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public Color playerColor = Color.white;
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponentInChildren<Movement>().enabled = true;
            Renderer[] rends = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
                r.material.color = playerColor;
        }
    }

}
