using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{

    public float speed1 = 30f;
    public float speed2 = 60f;
    public float direction;

    private bool hiding = false;


    public float camWidth, camHeight;
    public float radius = 1f;

    public string frameState = "in water";

    public GameObject tako;
    public GameObject winSound;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;



    //Serial Communication
    SerialPort sp = new SerialPort("COM4", 9600);



    private void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;


        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // sp.Open() will throw an error if it can't find an arduino and this "try" block will catch that error and allow the game to keep running
        try
        {
            sp.Open();
            sp.ReadTimeout = 25;
        }
        catch (System.Exception)
        {
            Debug.Log("Controller Not Found!");
        }

    }




    void Update()
    {
        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
                // MoveObject(sp.ReadByte());
                //print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

        //MOVEMENT FOR DEBUGGING
      //  float xAxis = Input.GetAxis("Horizontal");
       // float yAxis = Input.GetAxis("Vertical");
       //  Change position based on input
        Vector3 pos = transform.position;
       // pos.x += xAxis * speed1 * Time.deltaTime;
       // pos.y += yAxis * speed1 * Time.deltaTime;
       // transform.position = pos;




        if (frameState == "in water")
        {
            tako.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        if (frameState == "out water")
        {
            tako.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

    }



    private void LateUpdate()
    {
        Vector3 finalPos = transform.position;

        if (finalPos.x < camWidth - radius)
        {
            finalPos.x = camWidth - radius;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        Debug.Log(otherGO.tag);
        if (otherGO.tag == "water")
        {
            frameState = "in water";
        }
        if (otherGO.tag == "prop")
        {
            Debug.Log("hidden");
            hiding = true;
            Physics2D.IgnoreLayerCollision(8, 9, true);
        }
        if (otherGO.tag == "Win state")
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    GameObject otherGO = other.gameObject;
        if(otherGO.tag == "water")
        {
            frameState = "out water";
        }
    if (otherGO.tag == "prop")
    {
        Debug.Log("open");
        hiding = false;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    }   

}

