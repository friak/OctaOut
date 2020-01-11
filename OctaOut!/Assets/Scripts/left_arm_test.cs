using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;


public class left_arm_test : MonoBehaviour
{


    //positioning for tentacle 
    private float posl1 = 0f;
    private float posl2 = 0f;
    private float posl3 = 0f;
    private float posl4 = 0f;

    private float posr1 = 0f;
    private float posr2 = 0f;
    private float posr3 = 0f;
    private float posr4 = 0f;


    public float speed = 10f;

    public GameObject tako;
    private Rigidbody2D rb2d;

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;

    public GameObject splash;


    //Serial Communication
    SerialPort leftstream = new SerialPort("COM11", 38400);
    SerialPort rightstream = new SerialPort("COM4", 38400);

    void Start()
    {
        try
        {
            leftstream.Open();
            leftstream.ReadTimeout = 1;

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

            string[] ldata = leftstream.ReadLine().Split(','); //Read the information
            float l1val = float.Parse(ldata[0]);
            float l2val = float.Parse(ldata[1]);
            float l3val = float.Parse(ldata[2]);
            float l4val = float.Parse(ldata[3]);

            //Debug.Log(ldata[0]);

            string[] rdata = rightstream.ReadLine().Split(','); //Read the information
            float r1val = float.Parse(rdata[0]);
            float r2val = float.Parse(rdata[1]);
            float r3val = float.Parse(rdata[2]);
            float r4val = float.Parse(rdata[3]);

            //Debug.Log(rdata[0]);



            //LEFT HAND
            if (l1val <= 356 || Input.GetKey(KeyCode.F))
            {
                // Debug.Log("bend" + pos);

                posl1 += 2f * speed;
                l1.transform.localRotation = Quaternion.Euler(0, 0, posl1);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                // Debug.Log("no bend");
                posl1 = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


            if (l2val <= 356 || Input.GetKey(KeyCode.D))
            {
                Debug.Log("bend" + posl2);

                posl2 += 2f * speed;
                l2.transform.localRotation = Quaternion.Euler(0, 0, posl2);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                Debug.Log("no bend");
                posl2 = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (l3val <= 356 || Input.GetKey(KeyCode.S))
            {
                Debug.Log("bend" + posl3);

                posl3 += 2f * speed;
                l3.transform.localRotation = Quaternion.Euler(0, 0, posl3);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                Debug.Log("no bend");
                posl3 = 0f;
                l3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (l4val <= 356 || Input.GetKey(KeyCode.A))
            {
                Debug.Log("bend" + posl4);

                posl4 += 2f * speed;
                l4.transform.localRotation = Quaternion.Euler(0, 0, posl4);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                Debug.Log("no bend");
                posl4 = 0f;
                l4.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }




            //RIGHT HAND
            if (r1val <= 356 || Input.GetKey(KeyCode.J))
            {
                // Debug.Log("bend" + pos);

                posr1 += 2f * speed;
                r1.transform.localRotation = Quaternion.Euler(0, 0, posr1);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                //        Debug.Log("no bend");
                posr1 = 0f;
                r1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


            if (r2val <= 356 || Input.GetKey(KeyCode.K))
            {
                Debug.Log("bend" + posr2);

                posr2 += 2f * speed;
                r2.transform.localRotation = Quaternion.Euler(0, 0, posr2);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                Debug.Log("no bend");
                posr2 = 0f;
                r2.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (r3val <= 356 || Input.GetKey(KeyCode.L))
            {
                Debug.Log("bend" + posr3);

                posr3 += 2f * speed;
                r3.transform.localRotation = Quaternion.Euler(0, 0, posr3);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                Debug.Log("no bend");
                posr3 = 0f;
                r3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (r4val <= 356 || Input.GetKey(KeyCode.Semicolon))
            {
                Debug.Log("bend" + posr4);

                posr4 += 2f * speed;
                r4.transform.localRotation = Quaternion.Euler(0, 0, posr4);
                Vector2 force = new Vector2(-5, 10);
                rb2d.AddForce(force);
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
