using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        setXQuad(rb.position.x);
        setYQuad(rb.position.y);

        if(rb.position.y <= -10){
            rb.position = new Vector3(-16,-7,0);
        }


    }

    private void setXQuad(float x){
        if(x >= 24f && x <= 63f){
            cam.position = new Vector3(47f,cam.position.y,-10);
            return;
        }
        else if(x > 63f && x <= 100f){
            cam.position = new Vector3(86f,cam.position.y,-10);
            return;
        }
        else if(x < 24){
            cam.position = new Vector3(0f,cam.position.y,-10);
            return;
        }
    }



    private void setYQuad(float y){
        if(y >= -10f && y <= 10f){
            cam.position = new Vector3(cam.position.x,0f,-10);
            return;
        }
        else if(y > 10f && y <= 29f){
            cam.position = new Vector3(cam.position.x,19.8f,-10);

            return;
        }
        else if (y > 29){
            cam.position = new Vector3(cam.position.x,38.9f,-10);

            return;
        }
    }

}
