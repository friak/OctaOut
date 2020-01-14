using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{

    //frame states for tutorial cards
    public string frameState = "start"; //player is idle
    public float timeOut = 0f; //time within each state

    public GameObject Music;

    //Tutorial sprites
    public Sprite startscreen;
    public Sprite tutorial1;
    public Sprite tutorial2;
    public Sprite tutorial3;
    public Sprite tutorial4;
    public Sprite tutorial5;
    public Sprite toblack;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2d;

    //Serial Communication
    SerialPort leftstream = new SerialPort("COM11", 38400);


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

        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = startscreen;

    }

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

                if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "start")
                {
                    FindObjectOfType<AudioManager>().Play("Next");
                    frameState = "tutorial1";
                    timeOut = 1f;

                }
                else if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "tutorial1" && timeOut <= 0f)
                {
                    FindObjectOfType<AudioManager>().Play("Next");
                    frameState = "tutorial2";
                    timeOut = 1f;

                }
                else if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "tutorial2" && timeOut <= 0f)
                {
                    FindObjectOfType<AudioManager>().Play("Next");
                    frameState = "tutorial3";
                    timeOut = 1f;

                }
                else if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "tutorial3" && timeOut <= 0f)
                {
                    FindObjectOfType<AudioManager>().Play("Next");
                    frameState = "tutorial4";
                    timeOut = 1f;

                }
                else if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "tutorial4" && timeOut <= 0f)
                {
                    FindObjectOfType<AudioManager>().Play("Next");
                    frameState = "tutorial5";
                    timeOut = 1f;

                }
                else if ((l1val <= 356 || Input.GetKey(KeyCode.A)) && frameState == "tutorial5" && timeOut <= 0f)
                {
                    FindObjectOfType<AudioManager>().Play("Start");
                    Destroy(Music);
                    spriteRenderer.sprite = toblack;
                    frameState = "done";
                    timeOut = 5f;

                }
            }
            catch (System.Exception)
            {

            }


            //FRAME STATES

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
            if (frameState == "tutorial5")
            {
                if (timeOut >= 0)
                {
                    spriteRenderer.sprite = tutorial5;
                    timeOut -= Time.deltaTime;
                }
            }
            if (frameState == "done")
            {
                if (timeOut >= 0)
                {
                    timeOut -= Time.deltaTime;
                }
                else
                {
                    SceneManager.LoadScene("Level_One");
                }


            }
        }
    }
}


