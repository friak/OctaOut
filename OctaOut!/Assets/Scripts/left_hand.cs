using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class left_hand : MonoBehaviour
{

  //   private bool jsUp = false;
    // private bool jsDown = false;
    // idk debugging for later


    //positioning for tentacle 
    private float pos = 0f;


    private GameObject l1;
    private GameObject l2;
    private GameObject l3;
    private GameObject l4;

    public GameObject tako;



    public float speed = 10f;

    private Rigidbody2D rb2d;


    //Serial Communication
    SerialPort sp = new SerialPort("COM11", 9600);



    void Start()
    {
        // sp.Open() will throw an error if it can't find an arduino and this "try" block will catch that error and allow the game to keep running
        try
        {
            sp.Open();
            sp.ReadTimeout = 25;
        }
        catch (System.Exception)
        {
            Debug.Log("Controller 1 Not Found!");
        }
        Debug.Log("Controller Not Found!");


        rb2d = tako.GetComponent<Rigidbody2D>();


        l1 = GameObject.Find("L1");
        l2 = GameObject.Find("L2");
        l3 = GameObject.Find("L3");
        l4 = GameObject.Find("L4");
    }

    

    void Update()
    {
        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                //print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.name == "L4")
            {
                Debug.Log("bend");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                Debug.Log("nope");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.S))
        {
            if (gameObject.name == "L3")
            {
                Debug.Log("bend");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(10, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                Debug.Log("nope");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.name == "L2")
            {
                Debug.Log("bend");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(10, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                Debug.Log("nope");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.F))
        {
            if (gameObject.name == "L1")
            {
                Debug.Log("bend");
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                Debug.Log("nope");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

    }
    //DATA FROM ARDUINO CODE
    void MoveObject(int data)
    {
        Debug.Log(data);
        if (data == 1)
        {

            if (gameObject.name == "L1")
            {
                Debug.Log("bend1");
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (data == 2)
        {
            if (gameObject.name == "L2")
            {
                Debug.Log("bend2");
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(10, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (data == 3)
        {
            if (gameObject.name == "L3")
            {
                Debug.Log("bend3");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(10, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (data == 4)
        {
            if (gameObject.name == "L4")
            {
                Debug.Log("bend4");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }



}
