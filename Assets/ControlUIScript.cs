using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUIScript : Movement
{
    public bool left;
    public bool right;

    // Update is called once per frame
    public void IsLeftPushed()
    {
        left = true;
       
    }

    public void IsLeftLeft()
    {
        left = false;
    }

    public void IsRightPushed()
    {
        right = true;
    }

    public void IsRightLeft()
    {
        right = false;
    }
    void Update()
    {
        Debug.Log(horizontal);
        if (left)
        {
            horizontal = -1;
        }
        else if (right)
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }
    }

    private void FixedUpdate()
    {
        //wzor na poruszanie
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        //obrót
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }
}
