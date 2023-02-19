using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;

    // field to pick jumpable ground
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX *6, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && (IsGrounded() || StickyLeft() || StickyRight())){
            rb.velocity = new Vector2(rb.velocity.x, 16f);
        }


        // setXQuad(rb.position.x);
        // setYQuad(rb.position.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool StickyRight()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .2f, jumpableGround);
    }

    private bool StickyLeft()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .2f, jumpableGround);
    }


}
