using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{

    public float speed1 = 30f;
    public float speed2 = 60f;
    public float direction;
    public int collisionCount1 = 0;
    public int collisionCount2 = 0;

    private bool hiding = false;

    public float camWidth, camHeight;
    public float radius = 1f;

    public string frameState = "in water";

    public GameObject tako;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;

    public Sprite tako_head;
    public Sprite tako_sweat;
    public Sprite tako_hurt;
    public Sprite tako_yay;
    private SpriteRenderer spriteRenderer;



    private void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;


        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = tako_head;

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

        if (otherGO.tag == "water")
        {
            frameState = "in water";
            //    FindObjectOfType<AudioManager>().Play("Swim");
        }
        if (otherGO.tag == "prop")
        {
            // Debug.Log("hidden");
            hiding = true;
            spriteRenderer.sprite = tako_head;
            Physics2D.IgnoreLayerCollision(8, 9, true);
        }
        if (otherGO.tag == "danger")
        {
            collisionCount1 += 1;
            FindObjectOfType<AudioManager>().Play("Damage");
            spriteRenderer.sprite = tako_hurt;
            Vector2 force = new Vector2(-50, -50);
            rb2d.AddForce(force);

            //Debug.Log("collision amount" + collisionCount1);
            if (collisionCount1 == 9)
            {
                SceneManager.LoadScene("Lose_Two");
            }
        }
        if (otherGO.tag == "clear")
        {
            collisionCount2 += 1;
            if (collisionCount2 == 1)
            {
                FindObjectOfType<AudioManager>().Play("Clear");
                spriteRenderer.sprite = tako_yay;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.tag == "water")
        {
            FindObjectOfType<AudioManager>().Play("Splash");
            frameState = "out water";
        }
        if (otherGO.tag == "prop")
        {
            //    Debug.Log("open");
            hiding = false;
            FindObjectOfType<AudioManager>().Play("Worry");
            spriteRenderer.sprite = tako_sweat;
            Physics2D.IgnoreLayerCollision(8, 9, false);
        }
        if (otherGO.tag == "danger")
        {
            spriteRenderer.sprite = tako_head;
        }

    }
}



