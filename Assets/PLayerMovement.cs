using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX;
    private SpriteRenderer sprite;

    // field to pick
    [SerializeField] private LayerMask block;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveForce;

    
    private enum MovState {idle, running, jumping, falling, walljump};
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {   

        dirX = Input.GetAxisRaw("Horizontal");

        if(dirX != 0){
            rb.velocity = new Vector2(dirX *moveForce, rb.velocity.y);
        }
        
        if (Input.GetButtonDown("Jump") && (IsGrounded() || StickyLeft() || StickyRight())){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();


        // setXQuad(rb.position.x);
        // setYQuad(rb.position.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool StickyRight()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .2f, block);     
    }

    private bool StickyLeft()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .2f, block);
    }


    private void UpdateAnimationState(){

        

        MovState state = MovState.idle;
        if ((dirX > 0f)){
                state = MovState.running;
                sprite.flipX = false;
        }else if ((dirX < 0f)){
                state = MovState.running;
                sprite.flipX = true;
        }else{
                state = MovState.idle;
        }

        if(rb.velocity.y > 0.0001f){
            state = MovState.jumping;
        }else if(rb.velocity.y < -0.0001f){
            state = MovState.falling;
        }

        anim.SetInteger("state", (int)state);
        }


}
