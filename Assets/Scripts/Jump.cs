using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 10;  // Control Jump Power
    public float fallForce = 1; // force of falling power
    public Transform FeetCollider;
    public LayerMask groundMask;
    bool _groundCheck; //ground
    bool _waterCheck; //water
    private Vector2 _gravityVector;


    // Start is called before the first frame update
    void Start()
    {   
        _gravityVector = new Vector2(0, -Physics2D.gravity.y); // defines the gravity
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundCheck = Physics2D.OverlapCapsule(FeetCollider.position, new Vector2(1, 0.2f), CapsuleDirection2D.Horizontal, 0, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && (_groundCheck || _waterCheck)) // if press space and is on ground or water, runs below code
        {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce); //makes the rigidbody jump in the y axis appealing to the jumpforce
        }

        if (_rigidbody2D.velocity.y < 0 && !_waterCheck) //velocity of falling and excludes it from happening if in water
        { 
        
        _rigidbody2D.velocity -= _gravityVector * (fallForce * Time.deltaTime);  //the force of fall times the time it takes
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   if (collision.tag == "Water") //checks if we are colliding with a object with the water tag
        {
            _waterCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water") //checks if we are colliding with a object with the water tag
        {
            _waterCheck = false;
        }
    }


}