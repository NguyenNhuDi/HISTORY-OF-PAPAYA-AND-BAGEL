using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Change Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
