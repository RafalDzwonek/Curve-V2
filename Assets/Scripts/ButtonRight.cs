using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRight : MonoBehaviour
{
    public bool active = false;
    public void onPress()
    {
        active = true;
    }

    public void onRelease()
    {
        active = false;
    }
}
