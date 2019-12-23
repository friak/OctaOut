using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class right_hand : MonoBehaviour
{


    //positioning for tentacle 
    private float pos = 0f;
    public float speed = 10f;

    private GameObject r1;
    private GameObject r2;
    private GameObject r3;
    private GameObject r4;

    public GameObject splash;

    public GameObject tako;

    private Rigidbody2D rb2d;


    //Serial Communication
    SerialPort stream = new SerialPort("COM4", 9600);


    void Start()
    {

        // sp.Open() will throw an error if it can't find an arduino and this "try" block will catch that error and allow the game to keep running
        try
        {
            stream.Open();
            stream.ReadTimeout = 25;
        }
        catch (System.Exception)
        {
            Debug.Log("Right Hand Not Found!");
        }

        rb2d = tako.GetComponent<Rigidbody2D>();


        r1 = GameObject.Find("R1");
        r2 = GameObject.Find("R2");
        r3 = GameObject.Find("R3");
        r4 = GameObject.Find("R4");


    }

    void Update()
    {
        //SERIAL
        if (stream.IsOpen)
        {
            try
            {
                MoveObject(stream.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }


        //KETBOARD DEBUG
        if (Input.GetKey(KeyCode.Semicolon))
        {
            if (gameObject.name == "R4")
            {

                pos += 2f * speed;
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

        if (Input.GetKey(KeyCode.L))
        {
            if (gameObject.name == "R3")
            {

                pos += 2f * speed;
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

        if (Input.GetKey(KeyCode.K))
        {
            if (gameObject.name == "R2")
            {
 
                Debug.Log("bend");
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

        if (Input.GetKey(KeyCode.J))
        {
            if (gameObject.name == "R1")
            {
                pos -= 2f * speed;
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

    //DATA FROM ARDUINO CODE
    void MoveObject(int data)
    {
       // Debug.Log(data);
        if (data == 1)
        {

            if (gameObject.name == "R1")
            {
                Instantiate(splash);
                Destroy(splash);
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
            if (gameObject.name == "R2")
            {
                Instantiate(splash);
                Destroy(splash);
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
            if (gameObject.name == "R3")
            {
                Instantiate(splash);
                Destroy(splash);
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

   //     else if (data == 4)
   //     {
     //       if (gameObject.name == "R4")
       //     {
        //        Instantiate(splash);
         //       Destroy(splash);
          //      Debug.Log("bend4");
            //    pos += 2f * speed;
           //     transform.localRotation = Quaternion.Euler(0, 0, pos);
            //    Vector2 force = new Vector2(5, 10);
             //   rb2d.AddForce(force);
           // }
           // else
          //  {
            //    pos = 0f;
             //   transform.localRotation = Quaternion.Euler(0, 0, 0);
           // }
      //  }
    }
}