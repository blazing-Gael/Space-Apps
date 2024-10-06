using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingAxe : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 45f;
    public float throwPower = 5.5f;
    public Rigidbody rb;
    public Collider col;

    public bool activated;
    public Transform par;
    public int damagePnts = 50;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        par = GameObject.FindWithTag("Camera").transform;
        activated = true;
        rb.AddForce(par.forward * throwPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            //transform.localEulerAngles += par.forward * rotationSpeed * Time.deltaTime;
            rb.AddTorque(rb.transform.TransformDirection(Vector3.forward) * rotationSpeed, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other) {
        activated = false;
        rb.isKinematic = true;  
        gameObject.tag = "axe";
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyLoco>().takeDamage(damagePnts);
        }
    }

    public void Interact()
    {
        if (activated)
        {
            return;
        }
        GameObject.Find("Player").GetComponent<playerAttack>().hasAxe = true;
        GameObject.Find("Player").GetComponent<playerAttack>().gotAxe = true;
        Destroy(gameObject);
    }

    public string GetDescription()
    {
        if (activated)
        {
            return "";
        }
        string txt = "Pick up";
        return txt;
    }
}
