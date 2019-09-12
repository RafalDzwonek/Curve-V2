using UnityEngine;
using UnityEngine.Networking;


public class Movement : NetworkBehaviour
{
    public float speed = 0f;
    public float rotationSpeed = 200f;
    public KeyCode buttonLeft = KeyCode.A;
    public KeyCode buttonRight = KeyCode.D;
    bool ready = false;
    GameObject buttons;

    public float horizontal = 0f;

    private void Start()
    {
        buttons = GameObject.FindGameObjectWithTag("Buttons");
    }

    void Update()
    {
        ButtonLeft left = buttons.GetComponentInChildren<ButtonLeft>();
        ButtonRight right = buttons.GetComponentInChildren<ButtonRight>();

        if (Input.GetKey(buttonLeft) || left.active)
        {
            horizontal = -1;
        }
        else if (Input.GetKey(buttonRight) || right.active)
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
            Object.Destroy(transform.parent.gameObject);
        }
    }

    public void SetSpeedToZero()
    {
        speed = 0;
    }
}
