using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class test : MonoBehaviour
{

   // private bool jsUp = false;
   // private bool jsDown = false;
   // idk debugging for later


    //positioning for tentacle 
    private float pos = 0f;
    public GameObject tentacle;
    public float speed = 10f;


    //Serial Communication
    SerialPort sp = new SerialPort("COM4", 9600);


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
       //         MoveObject(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("bend");
            pos -= 2f * speed;
            transform.localRotation = Quaternion.Euler(0, 0, pos);
        }
        else
        {
            pos = 0f;
            Debug.Log("nope");
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
 }