using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    private Text timerText;
    private float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        ResetTimer();
    }

    public void ResetTimer()
    {
        levelTime = 0.00f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelTime >= 0.0)
        {
            levelTime += Time.deltaTime;
            int min = Mathf.FloorToInt(levelTime / 60);
            int sec = Mathf.FloorToInt(levelTime % 60);
            timerText.text = min.ToString("00") + ":" + sec.ToString("00");

        }
    }
}
