using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform cam;
    public Transform attackPoint;
    public Transform head;
    public float attckRange = 0.5f;
    public int damagePnts = 50;
    public Vector3 standPos;
    public Vector3 crouchPos;


    public LayerMask enemyLayers;

    public GameObject throwingAxe;
    public GameObject Axe;
    public GameObject Rod;
    private bool isCrouching;
    public bool hasAxe = true;
    public bool gotAxe = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gotAxe)
        {
            Axe.SetActive(true);
            gotAxe = false;
        }
        if (hasAxe && Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (hasAxe && Input.GetMouseButtonDown(1))
        {
            axeThrow();
        }





        if (Input.GetKeyDown(KeyCode.G))
        {
            Axe.SetActive(!Axe.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.H) && Axe.activeSelf == false)
        {
            Rod.SetActive(!Rod.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
        }
        /* if (isCrouching)
        {
            Axe.SetActive(false);
            Rod.SetActive(false);
            head.position = crouchPos;
        }
        else
        {
            Axe.SetActive(true);
            head.position = standPos;
        } */



    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attckRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<enemyLoco>().takeDamage(damagePnts);
        }
    }

    void axeThrow()
    {
        animator.SetTrigger("Throw");
        hasAxe = false;
    }

    private void OnDrawGizmos() {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attckRange);
    }

    
}
