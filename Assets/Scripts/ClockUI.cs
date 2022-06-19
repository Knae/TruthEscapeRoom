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

    public float beginningHour;
    private float beginningHourRotation;
    public float beginningMinute;
    private float beginningMinuteRotation;

    private float day;
    private float realSecondsToIngameDay = 720f; // 12 minutes for 24 hours, two full rotation

    void Start()
    {
        //beginningHourRotation = -beginningHour * 30f; // 30 degrees per hour
        //beginningMinuteRotation = -beginningMinute * 6f; // 6 degrees per minute
        //hoursClockHand.eulerAngles = new Vector3(0, 0, beginningHourRotation);
        //minutesClockHand.eulerAngles = new Vector3(0, 0, beginningMinuteRotation);
        //day = ((beginningHour * 30f) / realSecondsToIngameDay) + ((beginningMinute * 0.2f) / realSecondsToIngameDay);
    }

    void Update()
    {
        day += Time.deltaTime / realSecondsToIngameDay;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;

        hoursClockHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 12f;
        minutesClockHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor((dayNormalized * hoursPerDay) + beginningHour).ToString("00");

        float minutesPerHour = 60f;

        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }
}