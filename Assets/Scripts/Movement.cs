using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float speed = 0f;
    public float rotationSpeed = 200f;
    public KeyCode buttonLeft = KeyCode.A;
    public KeyCode buttonRight = KeyCode.D;
    bool ready = false;

    float horizontal = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buttonLeft))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(buttonRight))
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
        transform.Rotate(Vector3.forward*-horizontal*rotationSpeed*Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //rzuć texboxa do tej formuły !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (col.tag == "killer")
        {
            GameManager.FindObjectOfType<GameManager>().TheEndgame();
            speed = 0f;
            rotationSpeed = 0f;
        }
    }

    public void SetSpeedToZero()
    {
        speed = 0;
    }
}
