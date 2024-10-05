using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingAxe : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float throwPower = 5.5f;
    public Rigidbody rb;
    public Collider col;

    public bool activated;
    public Transform par;

    // Start is called before the first frame update
    void Start()
    {
        par = GameObject.FindWithTag("Camera").transform;
        activated = true;
        rb.AddForce(par.forward * throwPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.localEulerAngles += par.forward * rotationSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider != col)
            return;
        activated = false;
        rb.isKinematic = true;  
        Debug.Log(other.gameObject.name);  
    }
}
