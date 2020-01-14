using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;


public class right_hand : MonoBehaviour
{


    //positioning for tentacle 
    private float posr1 = 0f;
    private float posr2 = 0f;
    private float posr3 = 0f;
    private float posr4 = 0f;


    public float speed = 10f;

    public GameObject tako;
    private Rigidbody2D rb2d;
    float maxVelocity = 6;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;


    //Serial Communication
    SerialPort rightstream = new SerialPort("COM4", 38400);

    void Start()
    {
        try
        {
            rightstream.Open();
            rightstream.ReadTimeout = 1;
        }
        catch (System.Exception)
        {
            Debug.Log("Hands Not Found!");
        }

        rb2d = tako.GetComponent<Rigidbody2D>();

    }



    void FixedUpdate()
    {
        try
        {
            //READING ARDUINO DATA

            string[] rdata = rightstream.ReadLine().Split(','); //Read the information
            float r1val = float.Parse(rdata[0]);
            float r2val = float.Parse(rdata[1]);
            float r3val = float.Parse(rdata[2]);
            float r4val = float.Parse(rdata[3]);

            Debug.Log(rdata[0]);



            //RIGHT HAND
            if (r1val <= 356 || Input.GetKey(KeyCode.J))
            {
                Debug.Log("bend" + posr1);

                posr1 -= 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                r1.transform.localRotation = Quaternion.Euler(0, 0, posr1);
                Vector2 force = new Vector2(5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                // Debug.Log("no bend");
                posr1 = 0f;
                r1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


            if (r2val <= 356 || Input.GetKey(KeyCode.K))
            {
                Debug.Log("bend" + posr2);

                posr2 -= 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                r2.transform.localRotation = Quaternion.Euler(0, 0, posr2);
                Vector2 force = new Vector2(5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posr2 = 0f;
                r2.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (r3val <= 358 || Input.GetKey(KeyCode.L))
            {
                Debug.Log("bend" + posr3);

                posr3 += 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                r3.transform.localRotation = Quaternion.Euler(0, 0, posr3);
                Vector2 force = new Vector2(-5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posr3 = 0f;
                r3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (r4val <= 357 || Input.GetKey(KeyCode.Semicolon))
            {
                Debug.Log("bend" + posr4);

                posr4 += 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                r4.transform.localRotation = Quaternion.Euler(0, 0, posr4);
                Vector2 force = new Vector2(-5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posr4 = 0f;
                r4.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


        }

        catch (System.Exception)
        {
            return;
        }

    }

}
