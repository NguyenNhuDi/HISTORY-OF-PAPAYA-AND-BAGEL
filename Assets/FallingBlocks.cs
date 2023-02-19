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
        Debug.Log(originalPos);
        Debug.Log("STARTED RESET");

        yield return new WaitForSeconds(ResetDelay);
        rb.bodyType = RigidbodyType2D.Static;
        rb.position = new Vector3(originalPos.x,originalPos.y,originalPos.z);

        
        rb.bodyType = RigidbodyType2D.Kinematic;

    }

    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(reset());
    
        
    }
}
