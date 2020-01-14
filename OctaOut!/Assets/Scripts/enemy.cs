using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private float intpos;
    private float direction = -1;
    public float maxDist;
    public float  minDist;
    public float speed;

    private string frameState = "hidden"; //player is idle
    public float timeOut = 0f;


    public GameObject tako;

    public GameObject standin;
    public Transform shotPoint;

    public Sprite front;
    public Sprite left;
    public Sprite right;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Vector2 intpos = transform.position;
        maxDist += transform.position.x;
        minDist -= transform.position.x;
    }

    private void Update()
    {
        if (frameState == "seen")
        {
            if (timeOut >= 0)
            {
                speed = 0;
                spriteRenderer.sprite = front;
                GameObject atk = Instantiate(standin, shotPoint.position, shotPoint.rotation);
                FindObjectOfType<AudioManager>().Play("Alert");
                timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
               
                SceneManager.LoadScene("Lose_One");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        switch (direction)
        {
            case -1:
                // Moving Left
                if (transform.position.x > minDist)
                {
                    spriteRenderer.sprite = left;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = 1;
                }
                break;
            case 1:
                //Moving Right
                if (transform.position.x < maxDist)
                {
                    spriteRenderer.sprite = right;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = -1;
                }
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.name == "Tako")
        {
            frameState = "seen";
            timeOut = .25f;
        }

        
    }

}