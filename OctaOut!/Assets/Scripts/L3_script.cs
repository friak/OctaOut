using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class L3_script : MonoBehaviour
{

    // private bool jsUp = false;
    // private bool jsDown = false;
    // idk debugging for later


    //positioning for tentacle 
    private float pos = 0f;
    public float speed = 10f;


    private GameObject l3;


    public GameObject tako;

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

       
        l3 = GameObject.Find("L3");
    }



    void Update()
    {
        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                // print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

    }

    //DATA FROM ARDUINO CODE
    void MoveObject(int data)
    {
        Debug.Log(data);


        if (data == 3)
        {
            if (gameObject.name == "L3")
            {
                Debug.Log("bend3");
                pos += 2f * speed;
                transform.localRotation = Quaternion.Euler(0, 0, pos);
                Vector2 force = new Vector2(5, 10);
                rb2d.AddForce(force);
            }
            else
            {
                pos = 0f;
                Debug.Log("nope3");
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }



}
