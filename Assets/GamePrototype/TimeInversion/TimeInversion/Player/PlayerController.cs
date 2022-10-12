using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public CollisionController coll;
    public Animator animator;

    [Header("Status")]
    public float faceDir;
    public float moveSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        faceDir = 1;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CollisionController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // input arrow
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");  
        Vector2 pos = new Vector2(x,y);
        Vector2 dir = new Vector2(xRaw, yRaw);
        
        animator.SetBool("OnGround", coll.onGround);
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("VelocityY", rb.velocity.y);

        // change direction
        if(xRaw != 0)
        {
            faceDir = xRaw > 0 ? 1 : -1;
            transform.localScale = new Vector3(faceDir, 1, 1);
        }
        
        
        //run
        rb.velocity = new Vector2(pos.x*moveSpeed, rb.velocity.y);
            
        
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        


    }
}
