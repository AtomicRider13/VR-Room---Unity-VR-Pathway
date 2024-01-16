
using UnityEngine;
using System;

public class ClockController : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;
    public GameObject secondSound;

    private void Start()
    {
        InvokeRepeating("SecondSound", 0, 1);
    }
    private void Update()
    {
        UpdateClock();
    }

    public void UpdateClock()
    {
        System.DateTime currentTime = System.DateTime.Now;

        float hoursAngle = (currentTime.Hour % 12 + currentTime.Minute / 60f) * 30f;

        float minuteAngle = currentTime.Minute * 6f;

        float secondAngle = currentTime.Second * 6f;

        Debug.Log("The current time is" + currentTime.Hour + ":" + currentTime.Minute + ":" + currentTime.Second);

        RotateClockHand(hourHand, hoursAngle);
        RotateClockHand(minuteHand, minuteAngle);
        RotateClockHand(secondHand, secondAngle);

        

    }

    public void RotateClockHand(Transform handTransform, float angle)
    {
        handTransform.rotation = Quaternion.Euler(-angle, 0f , 0f);
    }

    public void SecondSound()
    {
        Instantiate(secondSound);
    }
}
