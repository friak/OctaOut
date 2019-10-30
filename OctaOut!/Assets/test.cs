using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class test : MonoBehaviour
{

    private bool jsUp = false;
    private bool jsDown = false;

    //frame states
    private string frameState = "nobend"; //player is idle
    private float timeOut = 0f; //time within each state

    //...sprites
    public Sprite nobend;
    public Sprite bend;

    private SpriteRenderer spriteRenderer;


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

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = nobend;
    }

    void Update()
    {

        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }



    }




    //DEBUG
    void MoveObject(int data)
    {

        if (data == 1) //up
        {
            Debug.Log("bend");
            spriteRenderer.sprite = bend;
        }
        else if (data == 2)
        {
            Debug.Log("nope");
            spriteRenderer.sprite = nobend;
        }

    }
 }