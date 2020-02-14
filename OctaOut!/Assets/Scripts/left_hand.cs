using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System.IO;
using System.IO.Ports;


public class left_hand : MonoBehaviour
{


    //positioning for tentacle 
    private float posl1 = 0f;
    private float posl2 = 0f;
    private float posl3 = 0f;
    private float posl4 = 0f;


    public float speed = 10f;

    public GameObject tako;
    private Rigidbody2D rb2d;
    float maxVelocity = 6;

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;


    //Serial Communication
    SerialPort leftstream = new SerialPort("COM11", 38400);

    void Start()
    {
        try
        {
            leftstream.Open();
            leftstream.ReadTimeout = 1;
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

            Debug.Log(ldata[0]);



            //LEFT HAND
            if (l1val <= 358 || Input.GetKey(KeyCode.F))
            {
                Debug.Log("bendl1" + posl1);

                posl1 -= 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                l1.transform.localRotation = Quaternion.Euler(0, 0, posl1);
                Vector2 force = new Vector2(5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                // Debug.Log("no bend");
                posl1 = 0f;
                l1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


            if (l2val <= 358 || Input.GetKey(KeyCode.D))
            {
                Debug.Log("bendl2" + posl2);

                posl2 -= 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                l2.transform.localRotation = Quaternion.Euler(0, 0, posl2);
                Vector2 force = new Vector2(5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posl2 = 0f;
                l2.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (l3val <= 358 || Input.GetKey(KeyCode.S))
            {
                Debug.Log("bendl3" + posl3);

                posl3 += 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                l3.transform.localRotation = Quaternion.Euler(0, 0, posl3);
                Vector2 force = new Vector2(-5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posl3 = 0f;
                l3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (l4val <= 356 || Input.GetKey(KeyCode.A))
            {
                Debug.Log("bendl4" + posl4);

                posl4 += 2f * speed;
                FindObjectOfType<AudioManager>().Play("Move");
                l4.transform.localRotation = Quaternion.Euler(0, 0, posl4);
                Vector2 force = new Vector2(-5, 6);
                if (rb2d.velocity.magnitude < maxVelocity)
                {
                    rb2d.AddForce(force);
                }
            }
            else
            {
                Debug.Log("no bend");
                posl4 = 0f;
                l4.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }



        }


        catch (System.Exception)
        {
            return;
        }

    }

}
