using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class go_menu : MonoBehaviour
{
    public GameObject Music;
    //Serial Communication
    SerialPort leftstream = new SerialPort("COM11", 38400);

    // Start is called before the first frame update
    void Start()
    {
        // sp.Open() will throw an error if it can't find an arduino and this "try" block will catch that error and allow the game to keep running
        try
        {
            leftstream.Open();
            leftstream.ReadTimeout = 25;
        }
        catch (System.Exception)
        {
            Debug.Log("Controller Not Found!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //SERIAL
        if (leftstream.IsOpen)
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

                //INPUTS

                if ((l1val <= 356 || Input.GetKey(KeyCode.A)))
                {
                    SceneManager.LoadScene("Level_One");
                    Destroy(Music);

                }
            }
            catch (System.Exception)
            {

            }
        }
    }
}
