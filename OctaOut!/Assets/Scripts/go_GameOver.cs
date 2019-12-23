using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_GameOver : MonoBehaviour
{

    public float timeOut = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOut >= 0)
        {
            timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
        }
        else
        {

            SceneManager.LoadScene("GameOver");
        }

    }
}
