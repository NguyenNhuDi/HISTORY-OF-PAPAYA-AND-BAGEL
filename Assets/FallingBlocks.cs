using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{

    private float fallDelay = 1f;
    private float ResetDelay = 10f;
    private Vector3 originalPos;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = rb.position;
    }

    private void  OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Fall());
        }
    }

    private IEnumerator reset(){
        yield return new WaitForSeconds(ResetDelay);

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.position = originalPos;

    }

    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(reset());
    
        
    }
}
