using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeft : MonoBehaviour
{
    public bool active = false;
    public void onPress()
    {
        Debug.Log("Left pressed");
        active = true;
    }

    public void onRelease()
    {
        active = false;
    }
}
