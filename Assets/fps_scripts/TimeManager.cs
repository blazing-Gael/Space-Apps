using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int startingMin;
    public int startingHour;
    public static Action onMinuteChanged;
    public static Action onHourChanged;
    public static Action onDayChanged;
    public static Action onMorning;
    public static Action onNoon;
    public static Action onEvening;

    public static int Minute {get; private set;}
    public static int Hour {get; private set;}

    [SerializeField]
    private float minuteToRealTime = 0.5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Minute = startingMin;
        Hour = startingHour;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;
            onMinuteChanged?.Invoke();

            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                onHourChanged?.Invoke();
                if (Hour >= 24)
                {
                    Hour = 0;
                    onDayChanged?.Invoke();
                }
            }

            timer = minuteToRealTime;
        }
        if (Hour == 6)
        {
            onMorning?.Invoke();
        }
        if (Hour == 12)
        {
            onNoon?.Invoke();
        }
        if (Hour == 18)
        {
            onEvening?.Invoke();
        }
    }
}
