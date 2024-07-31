using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer; //player image
    public float speed = 5; //player speed
    Rigidbody2D Rigid; //player pysics

    // start called before first frame update
    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    //update called once per frame
    private void Update()
    {
        //flips sprite if movement is 0 or more
        float xMovement = Input.GetAxis("Horizontal");
        if (xMovement >= 0) { SpriteRenderer.flipX = true; }
        if (xMovement <= 0) { SpriteRenderer.flipX = false; }

        //give speed to rigidbody
        Rigid.velocity = new Vector2(xMovement * speed, Rigid.velocity.y);


    }
}
