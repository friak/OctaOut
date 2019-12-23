using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;


public class left_hand : MonoBehaviour
{


    //positioning for tentacle 
    private float pos = 0f;
    public float speed = 10f;


    private GameObject l1;
    private GameObject l2;
    private GameObject l3;
    private GameObject l4;

    public GameObject splash;
    public GameObject tako;

    private Rigidbody2D rb2d;


    //Serial Communication
    SerialPort stream = new SerialPort("COM11", 38400);

    void Start()
    {
        try
        {
            stream.Open();
            stream.ReadTimeout = 1;
        }
        catch (System.Exception)
        {
            Debug.Log("Left Hand Not Found!");
        }

        rb2d = tako.GetComponent<Rigidbody2D>();


        l1 = GameObject.Find("L1");
        l2 = GameObject.Find("L2");
        l3 = GameObject.Find("L3");
        l4 = GameObject.Find("L4");


    }



    void Update()
    {

        if (stream.IsOpen)
        {
        //    Debug.Log("open!");
            try
            {

                string[] data = stream.ReadLine().Split(','); //Read the information
                Debug.Log(data[1]);
                float l1val = float.Parse(data[0]);
                float l2val = float.Parse(data[1]);
                float l3val = float.Parse(data[2]);
                float l4val = float.Parse(data[3]);

                
                {
                    if (l1val <= 1015)
                    {
                        Debug.Log(data[0]);
                        if (gameObject.name == "L1")
                        {
                            Instantiate(splash);
                            Destroy(splash);
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
                    if (l2val <= 1015)
                        {
                            Debug.Log("bend2");
                            if (gameObject.name == "L2")
                            {
                            Instantiate(splash);
                            Destroy(splash);
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
                    if (l3val <= 1015)
                    {
                            Debug.Log("bend3");
                            if (gameObject.name == "L3")
                            {
                            Instantiate(splash);
                            Destroy(splash);
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
                    if (l4val <= 1015)
                    {
                            Debug.Log("bend4");
                            if (gameObject.name == "L4")
                            {
                            Instantiate(splash);
                            Destroy(splash);
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
                    
                }
            }

            catch (System.Exception)
            {

            }
        }

        //KETBOARD DEBUG
        if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.name == "L4")
            {
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(-5, 5);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.S))
        {
            if (gameObject.name == "L3")
            {
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(-5, 5);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.name == "L2")
            {
                Debug.Log("bend");
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(5, 5);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }

        if (Input.GetKey(KeyCode.F))
        {
            if (gameObject.name == "L1")
            {
                pos -= 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(5, 5);
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
