using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DayNightManager : MonoBehaviour
{
    public TimeManager timeManager;
    public LightingPreset Preset;
    public Light sun;
    [SerializeField, Range(0,24)] private float TimeOfDay;
    public Material mornSky;
    public Material noonSky;
    public Material eveSky;
    public Material nightSky;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        TimeManager.onHourChanged += _hour;
        TimeManager.onMinuteChanged += _min;
        TimeManager.onMorning += _mornSky;
        TimeManager.onNoon += _noonSky;
        TimeManager.onEvening += _eveSky;
        TimeManager.onDayChanged += _nightSky;
        
    }

    private void OnDisable() {
        TimeManager.onHourChanged -= _hour;
        TimeManager.onMinuteChanged -= _min;
        TimeManager.onMorning -= _mornSky;
        TimeManager.onNoon -= _noonSky;
        TimeManager.onEvening -= _eveSky;
        TimeManager.onDayChanged -= _nightSky;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (sun != null)
        {
            sun.color = Preset.DirectionalColor.Evaluate(timePercent);

            //sun.transform.localRotation = Quaternion.Euler(Mathf.Lerp(Preset.startingRot,Preset.endingRot,timePercent), -90f, -90f);
            sun.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 270f, 0f));
            //sun.transform.localRotation = Quaternion.Lerp(Preset.startingRot, Preset.endingRot, timePercent);
        }

    }

    void _hour(){
        TimeOfDay += 1;
        TimeOfDay %= 24;
    }

    void _min(){
        TimeOfDay += 1/60;
        TimeOfDay %= 24;
    }

    void _mornSky(){
        RenderSettings.skybox = mornSky;

    }
    void _noonSky(){
        RenderSettings.skybox = noonSky;
    }
    void _eveSky(){
        RenderSettings.skybox = eveSky;
    }
    void _nightSky(){
        RenderSettings.skybox = nightSky;
    }
}
