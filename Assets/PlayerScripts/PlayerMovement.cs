using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public float moveSpeed;


    private bool handleinReach = false;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {

        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        move = new Vector2(x,y);


        if (handleinReach)
        {
            
        }
    }

    private void FixedUpdate()
    {

        player.AddForce(move);   
        //player.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Handle")
        {
            handleinReach = true;
        }
    }
}
