using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{

    public float speed1 = 30f;
    public float speed2 = 60f;
    public float direction;

    private bool hiding = false;


    public float camWidth, camHeight;
    public float radius = 1f;

    public string frameState = "in water";

    public GameObject tako;
    public GameObject splash;
    public GameObject split;


    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;



    private void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;


        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }




    void Update()
    {

        //MOVEMENT FOR DEBUGGING
    //    float xAxis = Input.GetAxis("Horizontal");
    //    float yAxis = Input.GetAxis("Vertical");
       //  Change position based on input
        Vector3 pos = transform.position;
    //    pos.x += xAxis * speed1 * Time.deltaTime;
    //    pos.y += yAxis * speed1 * Time.deltaTime;
    //    transform.position = pos;




        if (frameState == "in water")
        {
            tako.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        if (frameState == "out water")
        {
            tako.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }

    }



    private void LateUpdate()
    {
        Vector3 finalPos = transform.position;

        if (finalPos.x < camWidth - radius)
        {
            finalPos.x = camWidth - radius;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
   //     Debug.Log(otherGO.tag);
        if (otherGO.tag == "water")
        {
            frameState = "in water";
        }
        if (otherGO.tag == "prop")
        {
     //       Debug.Log("hidden");
            hiding = true;
            Physics2D.IgnoreLayerCollision(8, 9, true);
        }
        if (otherGO.tag == "Win state")
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    GameObject otherGO = other.gameObject;
        if(otherGO.tag == "water")
        {
            Instantiate(splash);
            Destroy(splash);
            Instantiate(split);
            Destroy(split);
            frameState = "out water";
        }
    if (otherGO.tag == "prop")
    {
    //    Debug.Log("open");
        hiding = false;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    }   

}

