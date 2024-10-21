using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePipe();
    }

    void MovePipe() 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        // Destroy the pipe if it goes off the screen
        if (transform.position.x < -18)
        {
            Destroy(gameObject);
        }
    }
}
