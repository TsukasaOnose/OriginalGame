using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    private int minute = 0;
    private float second = 0f;
    private GameObject timeText;

    public static readonly string Timetext = "Time Text";

    // Start is called before the first frame update
    void Start()
    {
        this.timeText = GameObject.Find(TimeDisplay.Timetext);
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
        if (second >= 60f)
        {
            minute++;
            second = -60;
        }

        //TimeをUIに表示
        timeText.GetComponent<Text>().text = minute.ToString("00") + ":" + second.ToString("00");
    }
}
