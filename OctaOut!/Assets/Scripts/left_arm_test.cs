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


    public float speed = 10f;

    public GameObject tako;
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;

    public GameObject splash;

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

    }



    void FixedUpdate()
    {

        //ARDUINO CONTROLS
        //Debug.Log("open!");
        try
        {

            string[] data = stream.ReadLine().Split(','); //Read the information
            float l1val = float.Parse(data[0]);
            float l2val = float.Parse(data[1]);
            float l3val = float.Parse(data[2]);
            float l4val = float.Parse(data[3]);

            //Debug.Log(data[1]);

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
                    //        Debug.Log("no bend");
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
            


        }
        catch (System.Exception)
        {
            return;
        }



        //KETBOARD DEBUG

            if (Input.GetKey(KeyCode.S))
            {
                posl3 -= 2f * speed;
                l3.transform.localRotation = Quaternion.Euler(0, 0, posl3);
                Vector2 force = new Vector2(5, 5);
                rb2d.AddForce(force);
            }
            else
            {
                posl3 = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


            if (Input.GetKey(KeyCode.A))
            {
                posl4 -= 2f * speed;
                l4.transform.localRotation = Quaternion.Euler(0, 0, posl4);
                Vector2 force = new Vector2(5, 5);
                rb2d.AddForce(force);
            }
            else
            {
                posl4 = 0f;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

        

    }

}
