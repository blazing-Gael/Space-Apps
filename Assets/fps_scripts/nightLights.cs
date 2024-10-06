using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightLights : MonoBehaviour, IInteractable
{
    public GameObject Lights;
    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            Lights.SetActive(true);
        }
    }


    public void Interact()
    {
        isOn = !isOn;
    }

    public string GetDescription()
    {
        string txt = "Flip  Outdoor Lights";
        return txt;
    }
}
