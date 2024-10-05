using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour, IInteractable
{
    public float health;
    public float mood;
    public float hygiene;


    public bool isHungry;
    public bool isSleepy;
    public bool sleeping;
    public bool hasBeenSlept;
    public bool HasBeenWoken;


    public float hunger_rate = 2f;


    private ParticleSystem currExp;


    public Animator anim;
    public ParticleSystem loveExp;
    public ParticleSystem stinkExp;
    public ParticleSystem sadExp;
    public ParticleSystem sleepExp;
    // Start is called before the first frame update

    public Quaternion rot;

    void Start()
    {
        health = 100f;
        mood = 100f;
        hygiene = 100f;
    }

    private void OnEnable() {
        TimeManager.onMorning += _hunger;
        TimeManager.onMorning += wakeUp;
        TimeManager.onNoon += _hunger;
        TimeManager.onEvening += _hunger;
        TimeManager.onDayChanged += _sleepy;
    }

    private void OnDisable() {
        TimeManager.onMorning -= _hunger;
        TimeManager.onMorning -= wakeUp;
        TimeManager.onNoon -= _hunger;
        TimeManager.onEvening -= _hunger;
        TimeManager.onDayChanged -= _sleepy;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }


        if (isHungry)
        {
            health -= hunger_rate * Time.deltaTime;
        }

        /* if (hasBeenSlept)
        {
            Instantiate(loveExp, transform.position, transform.rotation);
            anim.SetBool("asleep",true);
            sleeping = true;
        }
        if (HasBeenWoken)
        {
            anim.SetBool("asleep",true);
            sleeping = false;
            
            Instantiate(loveExp, transform.position, transform.rotation);
        } */
        /* if (Input.GetKeyDown(KeyCode.E))
        {
            HasBeenFed = true;          
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("asleep",false);          
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("asleep",true);          
        } */

    }

    private void _hunger(){
        isHungry = true;
        currExp = Instantiate(stinkExp, transform.position, rot);        
    }


    void _sleepy(){
        /* isSleepy = true;
        Instantiate(sleepExp, transform.position, rot); */
        anim.SetBool("asleep",true);
        sleeping = true;
    }

    void wakeUp(){
        anim.SetBool("asleep",false);
        sleeping = false;
    }

    public void Interact()
    {
        Debug.Log(health);
        if (isHungry)
        {
            isHungry = false;
            health = 100f;
            currExp.Stop();
            Destroy(currExp.gameObject);
            Instantiate(loveExp, transform.position, transform.rotation);
        }
    }

    public string GetDescription()
    {
        string txt = "";
        if (isHungry)
        {
            txt = "Feed Baba";
        }
        return txt;
    }


}
