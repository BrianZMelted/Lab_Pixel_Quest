using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer; //player image
    private float horizontal;
    private float speed = 8f;
    private bool canDash = true;
    private bool isDashing = true;
    private float dashPower = 24f;
    private float dashtime = 0.2f;
    private float dashCooldown = 1f;


    

    [SerializeField] private Rigidbody2D Rigid; //player pysics
    [SerializeField] private TrailRenderer tr;

    // start called before first frame update
    private void Start()
    {
        
    }

    //update called once per frame
    private void Update()
    {
        if (isDashing)
        {
            return;

        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(flash());

        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {

            return;
        }
        Rigid.velocity = new Vector2(horizontal * speed, Rigid.velocity.y);
    }

    private IEnumerator flash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = Rigid.gravityScale;
        Rigid.gravityScale = 0f;
        Rigid.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashtime);
        tr.emitting = false;
        Rigid.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
}