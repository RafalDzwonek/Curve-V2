using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUIScript : MonoBehaviour
{
    public bool left=false;
    public bool right=false;

    private void Start()
    {
       left = false;
        right = false;
    }

    public void IsLeftPressed()
    {
        left = true;
    }
    public void IsLeftLeft()
    {
        left = false;
    }

    public void IsRightPressed()
    {
        right = true;
    }

    public void IsRightLeft()
    {
        right = false;
    }

    void Update()
    {
        //Debug.Log(left);
        //Debug.Log(gameObject.GetComponent<Movement>().horizontal);
        //if (left)
        //{
        //    gameObject.GetComponent<Movement>().horizontal = -1;
        //}
        //else if (right)
        //{
        //    gameObject.GetComponent<Movement>().horizontal = 1;
        //}
        //else
        //{
        //    gameObject.GetComponent<Movement>().horizontal = 0;
        //}
    }



}
