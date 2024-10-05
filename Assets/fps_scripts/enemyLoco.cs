using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyLoco : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    public float deathLast = 3f;
    public ParticleSystem hitExp;
    public ParticleSystem dieExp;
    public Animator animator;
    public Vector3 target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            return;
        agent.SetDestination(target);
    }

    public void takeDamage(int damage)
    {
        Instantiate(hitExp, transform.position, transform.rotation);
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            StartCoroutine(kill());
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(deathLast);
        Instantiate(dieExp, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
