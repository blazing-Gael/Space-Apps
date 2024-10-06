using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    public Transform cam;

    public GameObject throwingAxe;
    private GameObject Axe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void axeThrow()
    {
        /* for (int i = 0; i < gameObject.transform.childCount ; i++)
        {
            MeshRenderer m = gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();
            if (m)
            {
                m.enabled = false;
            }
        } */
        Axe = Instantiate(throwingAxe, cam.position, cam.rotation);
        gameObject.SetActive(false);
    }
}
