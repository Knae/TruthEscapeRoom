using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockUI : MonoBehaviour
{
    public Transform hoursClockHand;
    public Transform minutesClockHand;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text taskText;
    public GameObject Late;

    public float beginningHour;
    public float beginningMinute;
    public float hourForWork;

    private float day;
    //private float realSecondsToIngameDay = 720f; // 12 minutes for 24 hours, two full rotation

    void Start()
    {
        //day = (beginningHour + (beginningMinute / 60f)) / 12f;
    }

    void Update()
    {
        day = StaticVariables.day; //Time.deltaTime / realSecondsToIngameDay;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;

        hoursClockHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 12f;
        minutesClockHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        float minutesPerHour = 60f;

        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;

        taskText.text = "Leave for work by " + StaticVariables.hourForWork;

        if (day > StaticVariables.hourForWork / 12f)
        {
            Late.SetActive(true);
        }
    }
}