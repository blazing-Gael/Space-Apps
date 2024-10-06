using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class HelperJoe : MonoBehaviour
{
    public Camera cam;
    public Animator animator;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    [Space]

    public Transform spellCastPoint;
    public Transform spellReach;
    public GameObject spell;
    public float spellRad = 2f;
    public int spellDamage = 50;
    [Space]

    public Transform patrolPoint;
    public float patrolRad;
    private GameObject currentTarget;
    public LayerMask layerMask;
    public bool Aggro = false;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Aggro == false)
        {
            return;
        }


        if (currentTarget == null)
        {
            Collider[] enemies = Physics.OverlapSphere(patrolPoint.position, patrolRad, layerMask);

            if (enemies.Length > 0)
                currentTarget = enemies[Random.Range(0,enemies.Length)].gameObject;
        }


        if (currentTarget != null)
            agent.SetDestination(currentTarget.transform.position);

        if (agent.remainingDistance > Vector3.Distance(spellCastPoint.position,spellReach.position))
        {
            character.Move(agent.desiredVelocity, false, false);    
        }
        else
        {
            character.Move(Vector3.zero, false, false);
            transform.LookAt(currentTarget.transform.position, transform.up);
            animator.SetTrigger("Cast");
            castSpell();
        }
        
    }

    public void castSpell()
    {
        GameObject magic = Instantiate(spell, spellCastPoint.position, spellCastPoint.rotation);
        Collider[] hitColliders = Physics.OverlapCapsule(spellCastPoint.position, spellReach.position, spellRad, layerMask);

        foreach (Collider collider in hitColliders)
        {
            collider.gameObject.GetComponent<enemyLoco>().takeDamage(spellDamage);
        }

        Destroy(magic,2f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(patrolPoint.position, patrolRad);
    }
}
