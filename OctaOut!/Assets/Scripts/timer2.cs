using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer2 : MonoBehaviour
{
    private Text timerText;
    private float levelTime;
    private GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        ResetTimer();
        music = GameObject.Find("Music");
    }

    public void ResetTimer()
    {
        levelTime = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelTime >= 0.0)
        {
            levelTime -= Time.deltaTime;
            timerText.text = "Returning to Start screen in  " + Mathf.Round(levelTime);
        }
        else
        {
            Destroy(music);
                SceneManager.LoadScene("Start_Scene");
        }
    }
}
