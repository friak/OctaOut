using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_one : MonoBehaviour
{

    private string frameState = "notclear"; //player is idle
    public float timeOut = 0f;


    public GameObject tako;
    public GameObject Music;
    public Sprite clear;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (frameState == "clear")
        {
            if (timeOut >= 0)
            {
                timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
                SceneManager.LoadScene("Win_One");
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;
        if (otherGO.tag == "tako")
        {
            GameObject.Find("Main Camera").GetComponent<follow_player>().enabled = false;
            Destroy(Music);
            spriteRenderer.sprite = clear;
            frameState = "clear";
            timeOut = 1f;
        }
    }


}
