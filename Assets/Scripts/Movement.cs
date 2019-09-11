using UnityEngine;
using UnityEngine.Networking;


public class Movement : NetworkBehaviour
{
    public float speed = 0f;
    public float rotationSpeed = 200f;
    public KeyCode buttonLeft = KeyCode.A;
    public KeyCode buttonRight = KeyCode.D;
    bool ready = false;
    bool button;

    public float horizontal = 0f;

    private void Start()
    {
        button = gameObject.GetComponent<ControlUIScript>().left;
    }

    void Update()
    {
        //Debug.Log(horizontal);
        /*if (gameObject.GetComponent<ControlUIScript>() == null)
        {
            Debug.Log("NIE ZNALEZIONO OBIEKTU ControlUIScript");
        }
        else if (gameObject.GetComponent<ControlUIScript>().left==null)
        {
            Debug.Log("LEFT JEST NULLEM");
        }
        else */ if (Input.GetKey(buttonLeft) || button==true )
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
            Object.Destroy(transform.parent.gameObject);
        }
    }

    public void SetSpeedToZero()
    {
        speed = 0;
    }
}
