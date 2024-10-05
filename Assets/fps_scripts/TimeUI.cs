using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        TimeManager.onMinuteChanged += updateTime;
        TimeManager.onHourChanged += updateTime;
    }

    private void OnDisable() {
        TimeManager.onMinuteChanged -= updateTime;
        TimeManager.onHourChanged -= updateTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateTime()
    {
        timeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
}
