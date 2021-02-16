using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    float timer;
    float seconds;
    float minutes;
    float hours;
    float milliseconds;

    [SerializeField] Text stopWatchText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StopWatchCalcul();
    }
    void StopWatchCalcul()
    {
        timer += Time.deltaTime;
        milliseconds = (int)((timer * 100) % 100);
        seconds = (int)(timer) % 60;
        minutes = (int)((timer / 60) % 60);
        hours = (int)(timer) / 3600;

        stopWatchText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
