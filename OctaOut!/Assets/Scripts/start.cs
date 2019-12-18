using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{

    //frame states
    private string frameState = "start"; //player is idle
    public float timeOut = 0f; //time within each state

    //...sprites
    public Sprite startscreen;
    public Sprite tutorial1;
    public Sprite tutorial2;
    public Sprite tutorial3;
    public Sprite tutorial4;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2d;

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

        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = startscreen;
    }

    void Update()
    {

        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
               // MoveObject(sp.ReadByte());
                //print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

        //FRAME STATE

        if (frameState == "start")
        {
            spriteRenderer.sprite = startscreen;
            timeOut -= Time.deltaTime;

        }
        if (frameState == "tutorial1")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = tutorial1;
                timeOut -= Time.deltaTime;
            }
 
        }
        if (frameState == "tutorial2")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = tutorial2;
                timeOut -= Time.deltaTime;
            }
 
        }
        if (frameState == "tutorial3")
        { 
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = tutorial3;
                timeOut -= Time.deltaTime;
            }
        }
        if (frameState == "tutorial4")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = tutorial4;
                timeOut -= Time.deltaTime;
            }
        }
        if (frameState == "done")
                if (timeOut >= 0)
                {
                    {

                    timeOut -= Time.deltaTime;
                    SceneManager.LoadScene("Game_Scene");
                }
           
        }



        //DEBUG KEYBOARD CONTROLS
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && frameState == "start")
        {
            frameState = "tutorial1";
            timeOut = 1f;

        }
         if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && frameState == "tutorial1" && timeOut <= 0)
        {
            frameState = "tutorial2";
            timeOut = 1f;
        }
         if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && frameState == "tutorial2" && timeOut <= 0)
        {
            frameState = "tutorial3";
            timeOut = 1f;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && frameState == "tutorial3" && timeOut <= 0)
        {
            frameState = "tutorial4";
            timeOut = 1f;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.F) && frameState == "tutorial4" && timeOut <=0)
        {
            frameState = "done";
            timeOut = 1f;
        }

    }

}