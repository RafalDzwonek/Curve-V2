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
        RpcSetNames();
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

    [ClientRpc]
    void RpcSetNames()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("player"))
        {
            p.name = p.transform.GetComponentInChildren<SetupLocalPlayer>().playerName;
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
        string winner = "nobobdy";
        string actualWinner = "Suicidal toughts huh?";
        //rzuć texboxa do tej formuły !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (col.tag == "killer")
        {     
            winner = col.transform.parent.name;
            Debug.Log("Uderzył: " + this.transform.parent.name);
            Debug.Log("Uderzył w: " + col.transform.parent.name);
            if (winner == this.transform.parent.name)
            {
                foreach (GameObject p in GameObject.FindGameObjectsWithTag("player"))
                {
                    if (p.name != winner)
                    {
                        actualWinner = p.name;
                    }             
                }
             winner = actualWinner;
            }
            GameManager.FindObjectOfType<GameManager>().RpcTheEndgame(winner);
        }       
    }

    public void SetSpeedToZero()
    {
        speed = 0;
    }
}
