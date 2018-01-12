using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeleraControllerBot : MonoBehaviour {

    Rigidbody2D rb;
    public float jump;
    public float Vel;
    public Transform Feet;
    public LayerMask lm;
    private Animator anim;
    private bool isGrounded = true;
    private bool isLookingRight = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        /* TODO */
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(Feet.position, 0.2f, lm);
		if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jump));
            /* TODO */
        }
        float move = Input.GetAxis("Horizontal");
        if ((move>0 && !isLookingRight) || (move < 0 && isLookingRight))
        {
            Flip();
        }
        rb.velocity = new Vector2(move*Vel, rb.velocity.y);
        /* TODO */
        
	}

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isLookingRight = !isLookingRight;
    }
}
